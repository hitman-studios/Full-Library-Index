namespace RazorLibraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Libraries;
public sealed class BorderColor
{
  internal ColorType colorType { get; private set; }
  public int Red { get => GetRed(); }
  public int Green { get => GetGreen();}
  public int Blue { get => GetBlue(); }
  public int Alpha { get; private set; }
  public int Hue { get => GetHue(); }
  public int Saturation { get => GetSaturation(); }
  public int Lightness { get => GetLightness(); }
  public static BorderColor RGB(int r, int g, int b) => new BorderColor(ColorType.RGB,r,g,b);
  public static BorderColor RGBA(int r, int g, int b, int a) => new BorderColor(ColorType.RGBA, r,g,b,a);
  public static BorderColor HSL(int h, int s, int l) => new BorderColor(ColorType.HSL, h, s, l);
  public static BorderColor HSLA(int h, int s, int l, int a) => new BorderColor(ColorType.HSLA, h, s, l, a);
  public static BorderColor HEX(string hex) => new BorderColor(ColorType.HEX,hex);
  public static 
  [TODO("include ColorType implementation.")]
  public int GetRed()
  {
    if(!(IsRGB || this.IsRGBA)) throw new InvalidColorException(colorType);
    else return parameter1;
  }
  [TODO("include ColorType implementation.")]
  public int GetGreen()
  {
    if(!(IsRGB || this.IsRGBA)) throw new InvalidColorException(colorType);
    else return parameter2;
  }
  [TODO("include ColorType implementation.")]
  public int GetBlue()
  {
    if(!(IsRGB || this.IsRGBA)) throw new InvalidColorException(colorType);
    else return parameter3;
  }
  [TODO("include ColorType implementation.")]
  public int GetHue()
  {
    if(!(IsHSL || this.IsHSLA)) throw new InvalidColorException(colorType);
    else return parameter1;
  }
  [TODO("include ColorType implementation.")]
  public int GetSaturation()
  {
    if(!(IsHSL || this.IsHSLA)) throw new InvalidColorException(colorType);
    else return parameter2;
  }
  [TODO("include ColorType implementation.")]
  public int GetLightness()
  {
    if(!(IsHSL || this.HSLA)) throw new InvalidColorException(colorType);
    else return parameter3;
  }
  public string HexCode
  {
    get
    {
      if(!IsHex) throw new InvalidColorException(colorType);
      else return hex;
    }
  }
  private string hex = "";
  private int parameter1;
  private int parameter2;
  private int parameter3;
  private BorderColor(ColorType type, int par1, int par2, int par3, int? alpha = null)
  {
    colorType = type;
    parameter1 = par1;
    parameter2 = par2;
    parameter3 = par3;
    Alpha = alpha != null ? alpha : 100;
  }
  public bool IsRGB => color.type == ColorType.RGB;
  public bool IsRGBA => color.type == ColorType.RGBA;
  public bool IsHSL => color.type == ColorType.HSL;
  public bool IsHSLA => color.type == ColorType.HSLA;
  public static bool IsHex(BorderColor color) => color.type == ColorType.HEX;
}
internal enum ColorType
{
HEX = 0,
RGB = 1,
HSL = 2,
RGBA = 3,
HSLA = 4
}
public class InvalidColorTypeException() : Exception
{
  public InvalidColorTypeException() : base("Invalid Permissions (Different Color Type)") {}
  public InvalidColorTypeException(Exception inner) : base("Invalid Permissions (Different Color Type)", inner) {}
  public InvalidColorTypeException(ColorType type, Exception inner) : base($"Expected {type.GetParameters()}", inner) {}
}