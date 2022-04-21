using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.InteropServices;
using System;
using Libraries;
namespace Libraries.Display;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
public class ConsoleLayerAttribute : Attribute
{
  public uint layer { get; }
  public ConsoleLayerAttribute([Optional]uint layer_)
  {
    layer = layer_;
  }
}
[AttributeUsage(AttributeTargets.Field | AttibuteTargets.Property, AllowMultiple = false, Inherited = false)]
public class ConsoleSubLayerAttribute : Attribute
{
  public int subLayer { get; }
  public ConsoleSubLayerAttribute([Optional]int subLayer_) {subLayer = subLayer_;}
}