using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
/**
<summary></summary>
<remarks>



</remarks>
*/
[Serializable,WIP]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
public class DataInfoAttribute : Attribute
{
  private static List<DataInfo> allDataInfo = new List<DataInfo>();
  public static void DisplayAll()
  {
    foreach(DataInfo info in allDataInfo.GetSortedList())
    {
      Console.WriteLine(info.GenerateOutput());
    }
  }
  public string ItemType { get; }
  public string Author { get; }
  public string Namespace { get; }
  public string dataType { get; }
  /**
<summary>Represents some data info to an extent.</summary>
<param name="ItemType">The name of the item</param>
<param name="Namespace">The namespace that holds the item</param>
<param name="author">The writer of the code</param>
<param name="type">The data Type ("record","record struct", "record class","ref struct","struct","class","static class","readonly struct","enum","interface")</param>
<remarks>
Recognized Data Types: "record","record struct", "record class","ref struct","struct","class","static class","readonly struct","enum","interface"
</remarks>
  */
  public DataInfoAttribute(string ItemType, string Namespace,string author, string type = "class")
  {
    this.ItemType = ItemType;
    this.Author = author;
    this.Namespace = Namespace;
    dataType = type;
    DataInfoAttribute.allDataInfo.Add(new DataInfo(ItemType,Namespace,author,type));
  }
  public DataInfo GetInfo() => new DataInfo(ItemType,Namespace,Author,dataType);
  public string GenerateOutput()=> $"Type: {ItemType}\nAuthor: {Author}\nData Type: {dataType}";
}
/**




*/
[Serializable]
public readonly struct DataInfo : IComparable<DataInfo>, IEquatable<DataInfo>
{
  public readonly string ItemName { get;}
  public readonly string Author { get;}
  public readonly string Namespace { get; }
  public readonly string dataType { get; }
  internal DataInfo(string itemName,  string Namespace_, string Author_, string dataType_)
  {
    ItemName = itemName;
    Namespace = Namespace_;
    Author = Author_;
    dataType = dataType_;
  }
  public int CompareTo(DataInfo other)
  {
    int c0 = ItemName.CompareTo(other.ItemName);
    int c2 = Author.CompareTo(other.Author);
    int c1 = dataType.CompareTo(other.dataType);
    return c0 == 0 ? c1 == 0 ? c2 : c1 : c0;
  }
  public bool Equals(DataInfo other) => ItemName.Equals(other.ItemName) && Author.Equals(other.Author) && dataType == other.dataType;
  public override string ToString() => $"DataInfoAttribute(Type {ItemName}, string {Author}, DataType {dataType})";
  public override bool Equals(object? other) => other != null && other is DataInfo info ? this.Equals(info) : false;
  public override int GetHashCode() => HashCode.Combine<string,string,string>(ItemName,Author,dataType);
  public string GenerateOutput() => $"Item: {dataType.ToLower()} {dataType}  {ItemName}\nAuthor: {Author}\n";
}