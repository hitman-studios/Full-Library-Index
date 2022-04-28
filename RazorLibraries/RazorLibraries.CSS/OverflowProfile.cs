namespace RazorLibraries.CSS;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
public sealed class OverflowProfile : IComponentStyle
{
  public OverflowType type { get; private set; } = OverflowType.Initial;
  public XYSides sides { get; private set; } = XYSides.None;
  public OverflowWrapType wrapType { get; private set; } = OverflowWrapType.Initial;
  private OverflowProfile(OverflowType type_, XYSides side)
  {
    type = type_;
    sides = side;
  }
  private OverflowProfile(OverflowType type_, XYSides side, OverflowWrapType wT)
  {
    type = type_;
    sides = side;
    wrapType = wT;
  }
  public bool IsInherit => type == OverflowType.Inherit;
  public bool IsInitial => type == OverflowType.Initial;
  public bool HasOverflow => sides != XYSides.None;
  public bool HasOverflowWrap => wrapType != OverflowWrapType.Initial;
  public string GenerateCSS()
  {
    string result = "";
    if(!HasOverflow) goto ret;
    if((sides & XYSides.X) != 0) result += $"overflow-x: {type.ToString().ToLower()};";
    if((sides & XYSides.Y) != 0) result += $"overflow-y: {type.ToString().ToLower()};";
    ret:
    if(HasOverflowWrap) result += $"overflow-wrap: {wrapType};";
    return result;
  }
}