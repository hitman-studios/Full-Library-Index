[assembly: TODO("ADD DOCUMENTATION.")]
namespace RazorLibraries.CSS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using Libraries;
/**
*/
[TODO("ADD DOCUMENTATION.")]
public sealed class BorderColor : IComponentStyle, IComparable<BorderColor>
{
/**
*/
  [TODO("ADD DOCUMENTATION.")]
  public string hexCode { get; }
/**
*/
  [TODO("ADD DOCUMENTATION.")]
  public byte red { get; }
/**
*/
  [TODO("ADD DOCUMENTATION.")]
  public byte blue { get; }
/**
*/
  [TODO("ADD DOCUMENTATION.")]
  public byte green { get; }
/**
*/
  [TODO("ADD DOCUMENTATION.")]
  public ColorType colorType { get; }
/**
*/
  public int CompareTo(BorderColor? other)
  {
    return other != null ? hexCode.CompareTo(other.hexCode) : 1;
  }
/**
*/
  [TODO("ADD DOCUMENTATION.")]
  private BorderColor(string hex)
  {
    if(hex.Equals("Inherit"))
    {
      colorType = ColorType.Inherit;
      red = 0;
      blue = 0;
      green = 0;
      hexCode = "Inherit";
    }
    else if(hex.Equals("Initial"))
    {
      colorType = ColorType.Initial;
      hexCode = "Initial";
      green = 0;
      blue = 0;
      red = 0;
    }
    else
    {
      colorType = ColorType.HexCode;
      var input = Setup(hex);
      red = input.r;
      blue = input.b;
      green = input.g;
      hexCode = hex;
    }
  }
/**
*/
  private BorderColor
  (byte r, byte g, byte b)
  {
    colorType = ColorType.RGB;
    hexCode = rgbToHex(r,g,b);
    red = r;
    blue = b;
    green = g;
  }
/**
*/
  public static BorderColor RGB(byte r, byte g, byte b)
  {
    return new BorderColor(r,g,b);
  }
/**
*/
  public static BorderColor HEX(string hex)
  {
    return new BorderColor(hex);
  }
/**
*/
  public static BorderColor Inherit() => new BorderColor("Inherit");
/**
*/
  public static BorderColor Initial() => new BorderColor("Initial");
/**
*/
  private string rgbToHex(byte r, byte g, byte b)
  {
    return Convert.ToString(r,16) + Convert.ToString(g,16) + Convert.ToString(b,16);
  }
/**
*/
  private (byte r, byte g, byte b) Setup(string hex)
  {
    byte r = 0;
    byte g = 0;
    byte b = 0;
    switch(hex.Length)
    {
      case 3:
        r = Convert.ToByte(hex[0].ToString(),16);
        g = Convert.ToByte(hex[1].ToString(),16);
        b = Convert.ToByte(hex[2].ToString(),16);
        break;
      case 6:
        r = Convert.ToByte(hex.Substring(0,2),16);
        g = Convert.ToByte(hex.Substring(2,2),16);
        b = Convert.ToByte(hex.Substring(4,2),16);
        break;
      default:
        break;
    }
    return (r,g,b);
  }
/**
*/
  public enum ColorType
  {
    HexCode = 0,
    RGB = 1,
    Inherit = 2,
    Initial = 3
  }
/**
*/
  public bool IsInherit => hexCode.Equals("Inherit");
/**
*/
  public bool IsInitial => hexCode.Equals("Initial");
/**
*/
  public string GenerateCSS() => IsInitial ? "initial " : IsInherit ? "inherit " : IsHex ? $"#{hexCode}" : $"rgb({red},{blue},{green})";
/**
*/
  public bool IsRGB => colorType == ColorType.RGB;
/**
*/
  public bool IsHex => colorType == ColorType.HexCode;
}