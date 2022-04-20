using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
internal struct TermPair : IComparable<TermPair>
{
  internal string Name { get; }
  internal string Description { get; set; }
  internal TermPair(string name, [Optional]string description)
  {
    Name = name;
    Description = description.Equals(default(string)) ? "" : description;
  }
  internal bool HasDescription => !Description.Equals("");
  public int CompareTo(TermPair other) => Name.CompareTo(other.Name);
  public static implicit operator TermPair(string name) => new TermPair(name);
  public static implicit operator TermPair((string name, string desc) setup) => new TermPair(setup.name, setup.desc);
}