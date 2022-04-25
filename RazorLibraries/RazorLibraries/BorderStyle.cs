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
  None = 0,
  Dotted = 1,
  Dashed = 2,
  Solid = 3,
  @Double = 4,
  Groove = 5,
  Ridge = 6,
  Inset = 7,
  Outset = 8,
  Hidden = 9
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
  public static string GetParameters(this ColorType type)
  {
    switch(type)
    {
      case ColorType.HEX:
        return "HexCode";
      case ColorType.RGB:
        return "Red, Green, or Blue";
      case ColorType.RGBA:
        return "Red, Green, Blue, or Alpha";
      case ColorType.HSL:
        return "Hue, Saturation, or Lightness";
      case ColorType.HSLA:
        return "Hue, Saturation, Lightness, or Alpha";
      default:
        return "W H A T";
    }
  }
}
public readonly struct Measurement : INumber, IEquatable<Measurement>,IEquatable<Number>,IEquatable<INumber>, IComparable<Measurement>,IComparable<Number>,IComparable<INumber>, IComponentStyle
{
  public string GenerateCSS() => $"{Value.ToString()} {measurement}";
  public readonly Number Value { get; }
  public readonly string measurement { get; }
  private Measurement(Number v, string m)
  {
    Value = Math.Abs(v.dValue);
    measurement = m;
  }
  public static Measurement Create(Number n, string s)
  {
    if(!s.IsMeasurement()) throw new Exception("Invalid measurement type.");
    else return new Measurement(n,s);
  }
  public Number ToNumber() => Value;
  public override string ToString() => $"{Value.iValue} {measurement}";
  // public override bool Equals(object obj) => 
  public bool Equals(Measurement other) => Value == other.Value && measurement.Equals(other.measurement);
  public bool Equals(Number other) => Value == other;
  public bool Equals(INumber? other) => other != null && Value == other.ToNumber();
  public int CompareTo(Number n) => Value.CompareTo(n);
  public int CompareTo(Measurement other) => Value.CompareTo(other.Value) == 0 ? measurement.CompareTo(other.measurement) : Value.CompareTo(other.Value);
  public int CompareTo(INumber? i) => i != null ? i is Measurement other ? this.CompareTo(other) : Value.CompareTo(i.ToNumber()) : 1;
}