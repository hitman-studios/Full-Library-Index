namespace RazorLibraries.CSS;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
[Flags]
public enum BorderSides
{
  None = 0,
  Top  = 0b0001,
  Right =0b0010,
  Bottom=0b0100,
  Left  =0b1000,
  Horizontal = 0b0101,
  Vertical   = 0b1010,
  All = 0b1111
}