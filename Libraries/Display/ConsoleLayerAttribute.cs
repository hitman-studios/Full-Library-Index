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
[AttributeUsage(AttributeTargets.Class,AllowMultiple =false, Inherited = false)]
public class DisplayableAttribute : Attribute
{
  public DisplayableAttribute() {}
}