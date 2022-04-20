using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
[Obsolete("DescriptionAttribute is useless now. Use SyntaxAttribute instead.")]
[AttributeUsage(AttributeTargets.All, Inherited=false)]
public class DescriptionAttribute : Attribute
{
  public string description { get; }
  public DescriptionAttribute(string descs)
  {
    description = descs;
  }
}