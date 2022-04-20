using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
public struct SyntaxInfo : IComparable<SyntaxInfo>, IEquatable<SyntaxInfo>
{
  public SyntaxInfo(string Name, string Namespace, string Description, string Author, string[] Remarks)
  {
    name = Name;
    description = Description;
    @namespace = Namespace;
    author = Author;
    remarks = Remarks;
  }
  public string name { get; }
  public string description { get; }
  public string author { get; }
  public string @namespace { get; }
  public string[] remarks { get; }
  public int CompareTo(SyntaxInfo other)
  {
    int c0 = @namespace.CompareTo(other.@namespace);
    int c1 = name.CompareTo(other.name);
    int c2 = author.CompareTo(other.author);
    int c3 = description.CompareTo(other.description);
    return c0 == 0 ? c1 == 0 ? c2 == 0 ? c3 : c2 : c1 : c0;
  }
  public string GenerateOutput()
  {
    string output = $"Namespace: {@namespace}\nName: {name}\nDescription: {description}\nAuthor: {author}\n\t";
    string outputp2 = "";
    foreach(string remark in remarks)
    {
      outputp2 += $"{remark}\n\t";
    }
    return output + outputp2;
  }
  public bool Equals(SyntaxInfo other)
  {
    return name.Equals(other.name) && description.Equals(other.description) && author.Equals(other.author) && remarks.Equals(other.remarks);
  }
}