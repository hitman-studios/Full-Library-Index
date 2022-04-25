using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
/**
<summary>Clarifies that an item is incomplete. Should be paired with <see cref="TODOAttribute"/></summary>
*/
[AttributeUsage(AttributeTargets.All,AllowMultiple=false,Inherited=false)]
public class WIPAttribute : Attribute
{
  public WIPAttribute() {}
}