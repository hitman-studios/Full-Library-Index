[assembly: TODO("ADD DOCUMENTATION.")]
namespace RazorLibraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Libraries;
[TODO("ADD DOCUMENTATION")]
public enum BorderSide
{
all = 0,
vertical = 1,
horizontal=2,
top  = 3,
right =4,
bottom=5,
left = 6
}
[TODO("ADD DOCUMENTATION.")]
public sealed class BorderProfile : IComponentStyle
{
  public BorderStyle borderStyle { get; private set;}
  public Measurement borderWidth { get; private set;}
  public BorderColor borderColor { get; private set; }
  private BorderProfile(BorderStyle style, Measurement measurement, [Optional]BorderColor color)
  {
    borderStyle = style;
    borderWidth = measurement;
    borderColor = color != null ? (BorderColor)color : BorderColor.Inherit();
  }
  private BorderProfile(BorderStyle style)
  {
    borderStyle = style;
    borderWidth = Measurement.Inherit();
    borderColor = BorderColor.Inherit();
  }
  private BorderProfile(BorderStyle style, string hex)
  {
    borderStyle = style;
    borderWidth = Measurement.Inherit();
    borderColor = BorderColor.HEX(hex);
  }
  private BorderProfile(BorderStyle style, BorderColor color)
  {
    borderStyle = style;
    borderWidth = Measurement.Inherit();
    borderColor = color;
  }
  private BorderProfile(BorderStyle style, byte r, byte g, byte b)
  {
    borderStyle = style;
    borderWidth = Measurement.Inherit();
    borderColor = BorderColor.RGB(r,g,b);
  }
  public static BorderProfile Inherit()
  {
    return new BorderProfile(BorderStyle.Inherit,Measurement.Inherit(),BorderColor.Inherit());
  }
  public static BorderProfile Initial()
  {
    return new BorderProfile(BorderStyle.Initial,Measurement.Initial(),BorderColor.Initial());
  }
  public static BorderProfile Create(BorderStyle style, Number length, string mType)
  {
    return new BorderProfile(style,Measurement.Create(length,mType));
  }
  public BorderProfile SetColor(string hex)
  {
    borderColor = BorderColor.HEX(hex);
    return this;
  }
  public BorderProfile SetColor(byte r, byte g, byte b)
  {
    borderColor = BorderColor.RGB(r,g,b);
    return this;
  }
  public BorderProfile SetColor(BorderColor c)
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
  public string GenerateCSS() => IsInitial ? "initial" : IsInherit ? "inherit" : HasBorder ?  $"border: {borderWidth.GenerateCSS()} {borderStyleCSS} {borderColorCSS}" : "none";
  public string borderColorCSS => borderColor.GenerateCSS();
  public string borderWidthCSS => borderWidth.GenerateCSS();
  public string borderStyleCSS => borderStyle.ToString().ToLower();
  public bool HasBorder => borderStyleCSS.Equals("none");
  public override string ToString() => IsInitial ? "initial" : IsInherit ? "inherit" : HasBorder ?  $"({borderStyleCSS}, {borderWidthCSS}, {borderColorCSS})" : "none";
  public static implicit operator BorderProfile((BorderStyle s, Measurement m) setup) => new BorderProfile(setup.s, setup.m);
  public static implicit operator BorderProfile((BorderStyle s, Measurement m, BorderColor c) setup) => new BorderProfile(setup.s, setup.m, setup.c);
  public static implicit operator BorderProfile((BorderStyle s, Measurement m, string c) setup) => new BorderProfile(setup.s, setup.m, BorderColor.HEX(setup.c));
  public static implicit operator BorderProfile((BorderStyle s, Measurement m, byte r, byte g, byte b) setup) => new BorderProfile(setup.s, setup.m, BorderColor.RGB(setup.r, setup.g, setup.b));
  public static implicit operator BorderProfile((BorderStyle s, Number n, string mT, byte r, byte g, byte b) setup ) => new BorderProfile(setup.s, Measurement.Create(setup.n, setup.mT), BorderColor.RGB(setup.r, setup.g, setup.b));
  public static implicit operator BorderProfile((BorderStyle s, Number n, string mT, string c) setup ) => new BorderProfile(setup.s, Measurement.Create(setup.n, setup.mT), BorderColor.HEX(setup.c));
  public static implicit operator BorderProfile((BorderStyle s, Number n, string mT) setup) => new BorderProfile(setup.s, Measurement.Create(setup.n,setup.mT));
  public static implicit operator BorderProfile((BorderStyle s, string hex) setup) => new BorderProfile(setup.s, BorderColor.HEX(setup.hex));
}