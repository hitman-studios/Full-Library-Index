namespace RazorLibraries.CSS;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
public enum OverflowType
{
  Inherit = -1,
  Initial = 0,
  Visible = 1,
  Hidden = 2,
  Scroll = 3,
  Auto = 4
}
[Flags]
public enum XYSides
{
  None = 0,
  X = 1,
  Y = 2,
  Both = 3
}