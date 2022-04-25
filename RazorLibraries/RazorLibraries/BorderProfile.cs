namespace RazorLibraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
public readonly struct BorderProfile : IComponentStyle
{
  public readonly string borderStyle { get; }
  public readonly Measurement measurement { get; }
  public BorderProfile(BorderStyle style, Measurement m)
  {
    borderStyle = style.ToString().ToLower();
    measurement = m;
  }
  public BorderProfile(BorderStyle style, Number n, string mType)
  {
    borderStyle = style.ToString().ToLower();
    try
    {
      measurement = n.CreateMeasurement(mType);
    }
    catch(Exception)
    {
      throw;
    }
  }
  public static BorderProfile Create(BorderStyle style, Number length, string mType)
  {
    // 
  }
  public string GenerateCSS() => $"{borderStyle} {measurement.GenerateCSS()}";
  public override string ToString() => $"({borderStyle}, {measurement.ToString()})";
  public static implicit operator BorderProfile((BorderStyle s, Measurement m) setup) => new BorderProfile(setup.s, setup.m);
  public static implicit operator BorderProfile((BorderStyle s, Number n, string mT) setup) => new BorderProfile(setup.s, setup.n, setup.mT);
}