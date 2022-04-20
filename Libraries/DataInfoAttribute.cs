using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
public sealed class DataInfoAttribute : Attribute
{
  public Type ItemType { get; }
  public string Author { get; }
  public DataType dataType { get; }
  public DataInfoAttribute(Type ItemType, string author, [Optional]DataType type)
  {
    this.ItemType = ItemType;
    this.Author = author;
    dataType = type;
    DataInfoAttribute.allDataInfo.Add(new DataInfo(ItemType,author,type));
  }
  private static List<DataInfo> allDataInfo = new List<DataInfo>();
  public string GenerateOutput()
  {
    string output = $"Type: {ItemType}\nAuthor: {Author}\nData Type: {dataType}";
    return "";
  }
}
public readonly struct DataInfo : IComparable<DataInfo>, IEquatable<DataInfo>
{
  public readonly Type ItemType { get;}
  public readonly string Author { get;}
  public readonly DataType dataType { get; }
  public DataInfo(Type ItemType_, string Author_, [Optional]DataType dataType_)
  {
    ItemType = ItemType_;
    Author = Author_;
    dataType = dataType_;
  }

  [TODO("FINISH DataInfo.CompareTo(DataInfo)")]
  public int CompareTo(DataInfo other) => 0;
  [TODO("FINISH DataInfo.Equals(DataInfo)")]
  public bool Equals(DataInfo other) => true;
}
public enum DataType
{
  Class = 0,
  Struct = 1,
  Interface = 2,
  Enum = 3
}