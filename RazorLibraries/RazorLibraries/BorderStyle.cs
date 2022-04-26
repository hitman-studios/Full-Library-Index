[assembly: TODO("ADD DOCUMENTATION.")]
namespace RazorLibraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
/**
<summary>Used to define the borderstyle CSS property for one,two,or all borders of a BorderSet</summary>
*/
public enum BorderStyle
{
  Inherit = 0,
  Initial = 1,
  None = 2,
  Dotted = 3,
  Dashed = 4,
  Solid = 5,
  @Double = 6,
  Groove = 7,
  Ridge = 8,
  Inset = 9,
  Outset = 10,
  Hidden = 11
}
public static class Measurements
{
  private static readonly string[] AbsoluteLengths = new string[]{
    "cm","mm","in","px","pt","pc"
  };
  private static readonly string[] RelativeLengths = new string[]{
    "em","ex","ch","rem","vw","vh","vmin","vmax","%"
  };
  public static bool IsRelativeMeasurement(this string s) => RelativeLengths.Contains(s);
  public static bool IsAbsoluteMeasurement(this string s) => AbsoluteLengths.Contains(s);
  public static bool IsMeasurement(this string s)
  {
    return AbsoluteLengths.Contains(s) || RelativeLengths.Contains(s);
  }
  public static Measurement CreateMeasurement(this Number n, string s)
  {
    return Measurement.Create(n,s);
  }
}
public readonly struct Measurement : INumber, IEquatable<Measurement>,IEquatable<Number>,IEquatable<INumber>, IComparable<Measurement>,IComparable<Number>,IComparable<INumber>, IComponentStyle
{
  public string GenerateCSS() => IsInherit ? "inherit" : IsInitial ? "initial" : $"{Value.ToString()} {measurement}";
  public readonly Number Value { get; }
  public readonly string measurement { get; }
  private Measurement(Number v, string m)
  {
    if(v < 0.0)
    {
      measurement = "Inherit";
      Value = 0;
    }
    else if(v == 0.0) 
    {
      measurement = "Initial";
      Value = 0;
    }
    else
    {
      measurement = m;
      Value = Math.Abs(v.dValue);
    }
  }
  public static Measurement Create(Number n, string s)
  {
    if(!s.ToLower().IsMeasurement()) throw new Exception("Invalid measurement type.");
    else return new Measurement(n,s.ToLower());
  }
  public static Measurement Inherit() => new Measurement(-1.0,"");
  public static Measurement Initial() => new Measurement(0.0,"");
  public Number ToNumber() => Value;
  public bool IsInitial => Value == 0.0d;
  public bool IsInherit => Value < 0.0d;
  public override string ToString() => IsInherit ? "Inherit" : IsInitial ? "Initial" : $"{Value.iValue} {measurement}";
  // public override bool Equals(object obj) => 
  public bool Equals(Measurement other) => Value == other.Value && measurement.Equals(other.measurement);
  public bool Equals(Number other) => Value == other;
  public bool Equals(INumber? other) => other != null && Value == other.ToNumber();
  public int CompareTo(Number n) => Value.CompareTo(n);
  public int CompareTo(Measurement other) => Value.CompareTo(other.Value) == 0 ? measurement.CompareTo(other.measurement) : Value.CompareTo(other.Value);
  public int CompareTo(INumber? i) => i != null ? i is Measurement other ? this.CompareTo(other) : Value.CompareTo(i.ToNumber()) : 1;
}