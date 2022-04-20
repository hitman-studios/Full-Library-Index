using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
/**
<summary>Adds Syntactical metadata to your code and helps people to understand.</summary>
<remarks>
Constructor Parameters: <br/>
<c>string ItemName</c> - the name of the item that is described. if it is a method, use proper signature. <br/>
<c>string ItemType</c> - the type of the item (class, struct, method, field( if so what type)) <br/>
<c>string Namespace</c> - the namespace that the item is defined in.
<c>string Description</c> - the description of the element.
<c>string Author</c> - the writer of the element.
<c>params string[] Remarks</c> - any additional information that is relevant to the syntax.
</remarks>
*/
[AttributeUsage(AttributeTargets.All, AllowMultiple=false, Inherited=false)]
public sealed class SyntaxAttribute : Attribute
{
  public string name { get; }
  public string description { get; }
  public string @namespace { get; }
  public string author { get; private set; }
  public string[] remarks { get; private set; }
/**
<summary></summary>
<param name="ItemName">The name of the element. If not a data type, include proper signature.</param>
<param name="ItemType">The type of element(class, struct, return value, etc.) that the code element is</param>
<param name="Namespace">The namespace that the code element is in.</param>
<param name="Description">The description of the code element.</param>
<param name="Author">The writer of the code element.</param>
<param name="Remarks">Any additional details that should be made.</param>
<remarks>
  Remarks is a params argument.
</remarks>
*/
  public SyntaxAttribute(string ItemName,string Namespace, string Description, string Author, params string[] Remarks)
  {
    name = ItemName;
    description = Description;
    @namespace = Namespace;
    author = Author;
    remarks = Remarks;
    SyntaxAttribute.allSyntax.Add(this.GetSyntax());
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
  public SyntaxInfo GetSyntax() => new SyntaxInfo(name, @namespace, description, author, remarks);
  private static List<SyntaxInfo> allSyntax = new List<SyntaxInfo>();
  public static SyntaxInfo[] GetAllSyntax() => allSyntax.ToArray();
  public static void PrintAllSyntax()
  {
    foreach(SyntaxInfo info in allSyntax)
    {
      Console.WriteLine(info.GenerateOutput());
    }
  }
}