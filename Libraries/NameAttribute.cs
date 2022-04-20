using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
[Obsolete("NameAttribute is useless now. Use SyntaxAttribute instead now.")]
[AttributeUsage(AttributeTargets.All,Inherited=false)]
public class NameAttribute : Attribute
{
  public string name { get; }
  public NameAttribute(string n)
  {
    name = n;
  }
}