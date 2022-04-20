using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
[Obsolete]
public class ItemNameExistsException : Exception
{
  public string Duplicate { get; }
  public ItemNameExistsException(string name) : base($"Item {name} already exists") {Duplicate = name; }
  public ItemNameExistsException(string name, Exception inner) : base($"Item {name} already exists",inner)
  {
    Duplicate = name;
  }
}