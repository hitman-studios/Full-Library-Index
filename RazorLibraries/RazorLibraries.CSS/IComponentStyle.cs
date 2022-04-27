namespace RazorLibraries.CSS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
internal interface IComponentStyle
{
  string GenerateCSS();
  bool IsInitial { get; }
  bool IsInherit { get; }
}