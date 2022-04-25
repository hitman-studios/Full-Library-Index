using System;
using System.Collections;
using System.Collections.Generic;
using Libraries;
using Libraries.Modeling;
namespace RazorLibraries;
public partial class VNumber : INumber
{
  public Number Value { get; set; } = 0.0;
  public Number ToNumber() => Value;
  public static explicit operator Number(VNumber v) => v.Value;
}