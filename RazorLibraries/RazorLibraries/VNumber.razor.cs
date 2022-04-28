using System;
using System.Collections;
using System.Collections.Generic;
using Libraries;
using Libraries.Modeling;
namespace RazorLibraries;
public partial class VNumber : INumber
{
  public Number nValue { get => Value; set => Value = value; }
  public Number ToNumber() => nValue;
  public static explicit operator Number(VNumber v) => v.nValue;
}