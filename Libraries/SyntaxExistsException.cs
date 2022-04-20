using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
[Obsolete]
public class SyntaxExistsException: Exception
{
  public SyntaxInfo Duplicate { get; }
  public SyntaxExistsException(SyntaxInfo info) : base($"{info.name} Syntax is already defined.")
  {
    Duplicate = info;
  }
  public SyntaxExistsException(SyntaxInfo info, Exception inner) : base($"{info.name} Syntax is already defined.", inner)
  {
    Duplicate = info;
  }
}