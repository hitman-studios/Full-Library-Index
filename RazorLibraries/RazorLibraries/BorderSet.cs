namespace RazorLibraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
public class BorderSet : IComponentStyle
{
  // public BorderProfile Top { get; }
  // public BorderProfile Right { get; }
  // public BorderProfile Bottom { get; }
  // public BorderProfile Left { get; }
  private BorderSet() {}
  public string GenerateCSS() => "";
  public bool IsInherit => false;
  public bool IsInitial => false;
}