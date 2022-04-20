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
  public string GenerateOutput()=> $"Type: {ItemType}\nAuthor: {Author}\nData Type: {dataType}";
}
public readonly struct DataInfo : IComparable<DataInfo>, IEquatable<DataInfo>
{
  public readonly Type ItemType { get;}
  public string ItemName { get => ItemType.ToString();}
  public readonly string Author { get;}
  public readonly DataType dataType { get; }
  public DataInfo(Type ItemType_, string Author_, [Optional]DataType dataType_)
  {
    ItemType = ItemType_;
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
  public override string ToString() => $"DataInfoAttribute(Type {ItemType}, string {Author}, DataType {dataType})";
  public override bool Equals(object? other) => other != null && other is DataInfo info ? this.Equals(info) : false;
  public override int GetHashCode() => HashCode.Combine<Type,string,DataType>(ItemType,Author,dataType);
  public string GenerateOutput() => $"Item: {dataType.ToString().ToLower()} {dataType}  {ItemType}\nAuthor: {Author}\n";
}
public enum DataType
{
  Class = 0,
  Struct = 1,
  Interface = 2,
  Enum = 3
}