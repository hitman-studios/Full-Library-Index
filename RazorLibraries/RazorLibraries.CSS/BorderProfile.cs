[assembly: TODO("ADD DOCUMENTATION.")]
namespace RazorLibraries.CSS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Libraries;
[TODO("ADD DOCUMENTATION.")]
public sealed class BorderProfile : IComponentStyle, IComparable<BorderProfile>
{
  public int CompareTo(BorderProfile? p)
  {
    if(p != null)
    {
    int c0 = borderStyle.CompareTo(p.borderStyle);
    int c1 = borderWidth.CompareTo(p.borderWidth);
    int c2 = borderColor.CompareTo(p.borderColor);
    return c0 != 0 ? c0 : c1 != 0 ? c1 : c2;
    }
    else return 1;
  }
  public BorderStyle borderStyle { get; private set;}
  public Measurement borderWidth { get; private set;}
  public Color borderColor { get; private set; }
  private BorderProfile(BorderStyle style, Measurement measurement, Color color)
  {
    borderStyle = style;
    borderWidth = measurement;
    borderColor = color;
  }
  private BorderProfile(BorderStyle style, Measurement measurement)
  {
    borderStyle = style;
    borderWidth = measurement;
    borderColor = Color.Inherit();
  }
  private BorderProfile(BorderStyle style, Color color)
  {
    borderStyle = style;
    borderWidth = Measurement.Inherit();
    borderColor = color;
  }
  private BorderProfile(BorderStyle style)
  {
    borderStyle = style;
    borderWidth = Measurement.Inherit();
    borderColor = Color.Inherit();
  }
  private BorderProfile(Measurement m, Color c)
  {
    borderStyle = BorderStyle.Inherit;
    borderWidth = m;
    borderColor = c;
  }
  private BorderProfile(Measurement m)
  {
    borderStyle = BorderStyle.Inherit;
    borderWidth = m;
    borderColor = Color.Inherit();
  }
  private BorderProfile(Color c)
  {
    borderStyle = BorderStyle.Inherit;
    borderWidth = Measurement.Inherit();
    borderColor = c;
  }
  private BorderProfile()
  {
    borderStyle = BorderStyle.Inherit;
    borderWidth = Measurement.Inherit();
    borderColor = Color.Inherit();
  }
  public static BorderProfile Inherit()
  {
    return new BorderProfile();
  }
  public static BorderProfile Initial()
  {
    return new BorderProfile(BorderStyle.Initial,Measurement.Initial(),Color.Initial());
  }
  public static BorderProfile Create(BorderStyle style, Measurement m, Color color)
  {
    return new BorderProfile(style,m,color);
  }
  public static BorderProfile Create(BorderStyle style, Measurement m)
  {
    return new BorderProfile(style,m,Color.Inherit());
  }
  public static BorderProfile Create(BorderStyle style)
  {
    return new BorderProfile(style);
  }
  public static BorderProfile Create(BorderStyle style, Color c)
  {
    return new BorderProfile(style, c);
  }
  public static BorderProfile Create(Measurement m, Color c)
  {
    return new BorderProfile(m,c);
  }
  public static BorderProfile Create(Measurement m)
  {
    return new BorderProfile(m);
  }
  public static BorderProfile Create(Color c)
  {
    return new BorderProfile(c);
  }
  // public static BorderProfile Create(BorderStyle style, Number length, string mType)
  // {
  //   return new BorderProfile(style,Measurement.Create(length,mType));
  // }
  // public static BorderProfile Create(BorderStyle style, Measurement measurement, Color color)
  // {
  //   return new BorderProfile(style,measurement, color);
  // }
  // public static BorderProfile Create(BorderStyle style, Measurement measurement)
  // {
  //   return new BorderProfile(style,measurement);
  // }
  // public static BorderProfile Create(BorderStyle style, Number length, string mT, byte r, byte g, byte b)
  // {
  //   return new BorderProfile(style, Measurement.Create(length, mT), Color.RGB(r,g,b));
  // }
  // public static BorderProfile Create(BorderStyle style, Number length, string mT, string hex)
  // {
  //   return new BorderProfile(style, Measurement.Create(length, mT), Color.HEX(hex));
  // }
  public BorderProfile SetColor(string hex)
  {
    borderColor = Color.HEX(hex);
    return this;
  }
  public BorderProfile SetColor(byte r, byte g, byte b)
  {
    borderColor = Color.RGB(r,g,b);
    return this;
  }
  public BorderProfile SetColor(Color c)
  {
    borderColor = c;
    return this;
  }
  public BorderProfile SetWidth(Measurement m)
  {
    borderWidth = m;
    return this;
  }
  public BorderProfile SetWidth(Number newWidth, [Optional]string mType)
  {
    borderWidth = Measurement.Create(newWidth,mType.Equals(default(string)) ? borderWidth.measurement: mType);
    return this;
  }
  public BorderProfile SetStyle(BorderStyle style)
  {
    borderStyle = style;
    return this;
  }
  public bool IsInitial => borderStyle == BorderStyle.Initial;
  public bool IsInherit => borderStyle == BorderStyle.Inherit;
  public string GenerateCSS() => IsInitial ? "initial" : IsInherit ? "inherit" : HasBorder ?  $"{borderWidth.GenerateCSS()} {borderStyleCSS} {borderColorCSS}" : "none";
  public string borderColorCSS => borderColor.GenerateCSS();
  public string borderWidthCSS => borderWidth.GenerateCSS();
  public string borderStyleCSS => borderStyle.ToString().ToLower();
  public bool HasBorder => borderStyleCSS.Equals("none");
  public override string ToString() => IsInitial ? "initial" : IsInherit ? "inherit" : HasBorder ?  $"({borderStyleCSS}, {borderWidthCSS}, {borderColorCSS})" : "none";
  public static implicit operator BorderProfile((BorderStyle s, Measurement m) setup) => new BorderProfile(setup.s, setup.m);
  public static implicit operator BorderProfile((BorderStyle s, Measurement m, Color c) setup) => new BorderProfile(setup.s, setup.m, setup.c);
  public static implicit operator BorderProfile((BorderStyle s, Measurement m, string c) setup) => new BorderProfile(setup.s, setup.m, Color.HEX(setup.c));
  public static implicit operator BorderProfile((BorderStyle s, Measurement m, byte r, byte g, byte b) setup) => new BorderProfile(setup.s, setup.m, Color.RGB(setup.r, setup.g, setup.b));
  public static implicit operator BorderProfile((BorderStyle s, Number n, string mT, byte r, byte g, byte b) setup ) => new BorderProfile(setup.s, Measurement.Create(setup.n, setup.mT), Color.RGB(setup.r, setup.g, setup.b));
  public static implicit operator BorderProfile((BorderStyle s, Number n, string mT, string c) setup ) => new BorderProfile(setup.s, Measurement.Create(setup.n, setup.mT), Color.HEX(setup.c));
  public static implicit operator BorderProfile((BorderStyle s, Number n, string mT) setup) => new BorderProfile(setup.s, Measurement.Create(setup.n,setup.mT));
  public static implicit operator BorderProfile((BorderStyle s, string hex) setup) => new BorderProfile(setup.s, Color.HEX(setup.hex));
}