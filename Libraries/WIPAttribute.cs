using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
[AttributeUsage(AttributeTargets.All,AllowMultiple=false,Inherited=false)]
public class WIPAttribute : Attribute
{
  private static int numberOfWIPs = 0;
  public WIPAttribute() { Extensions.Log($"A WIP attribute has just been identified.\nThis is number {++WIPAttribute.numberOfWIPs}");}
}