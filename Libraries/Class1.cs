using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
public static class Extensions
{
  public static bool TryGetCustomAttribute<In,Attr>(out Attr? attr) where Attr : Attribute
  {
    var attributes = (Attr[])typeof(In).GetCustomAttributes(typeof(Attr),true);
    bool output = attributes.Length > 0;
    attr = output ? attributes[0] : default(Attr);
    return true;
  }
  public static bool TryGetSyntax<T>(out SyntaxInfo? i)
  {
    SyntaxAttribute? synAttr;
    bool output = TryGetCustomAttribute<T,SyntaxAttribute>(out synAttr);
    i = synAttr != null ? ((SyntaxAttribute)synAttr).GetSyntax() : null;
    return output;
  }
  public static Out[] Pull<In,Out>(this In[] list, Func<In,Out> m)
  {
    List<Out> output = new List<Out>();
    foreach(In i in list)
    {
      output.Add(m(i));
    }
    return output.ToArray();
  }
  public static bool TryGetCustomAttributes<In,Out>(this In obj, out Out[]? retValue) where Out : Attribute
  {
    var customAttr = (Out[])typeof(In).GetCustomAttributes(typeof(Out),true);
    bool output = customAttr.Length > 0;
    retValue = output ? customAttr : default(Out[]);
    return output;
  }
  // public static T NotNull<T>(this T? t, out T output)
  // {
  //   bool retValue = t != null;
  //   return retValue ? t : typeof(T).InvokeMember();
  // }
  public static bool TryGetCustomAttribute<In,Out>(this In obj, out Out? retValue) where Out : Attribute
  {
    var customAttr = (Out[])typeof(In).GetCustomAttributes(typeof(Out),true);
    bool output = customAttr.Length > 0;
    retValue = output ? customAttr[0] : default(Out);
    return output;
  }
  public static Out? GetCustomAttribute<In,Out>(this In obj) where Out : Attribute
  {
    var customAttr = (Out[])typeof(In).GetCustomAttributes(typeof(Out),true);
    bool output = customAttr.Length > 0;
    return output ? customAttr[0] : default(Out);
  }
  public static Out[]? GetAllCustomAttributes<In,Out>(this In obj) where Out : Attribute
  {
    var customAttr = (Out[])typeof(In).GetCustomAttributes(typeof(Out),true);
    bool output = customAttr.Length > 0;
    return output ? customAttr : null;
  }
  public static bool TryGetSyntax<In>(this In obj, out SyntaxInfo? info)
  {
    SyntaxAttribute? synAttr;
    bool output = obj.TryGetCustomAttribute(out synAttr);
    info = output && synAttr != null ? synAttr.GetSyntax() : null;
    return output;
  }
  public static bool PrintSyntax<In>()
  {
    SyntaxInfo? info;
    bool output = TryGetSyntax<In>(out info);
    Console.WriteLine(info != null ? ((SyntaxInfo)info).GenerateOutput() : "No Syntax Provided.");
    return output;
  }
  public static SyntaxInfo GetSyntax<In>(this In obj)
  {
    SyntaxAttribute? synAttr;
    bool output = obj.TryGetCustomAttribute(out synAttr);
    return output && synAttr != null ? synAttr.GetSyntax() : default(SyntaxInfo);
  }
  public static Number Sum(this Number[] numbers)
  {
    Number result = 0.0;
    foreach(Number n in numbers)
    {
      result += n;
    }
    return result;
  }
  public static bool DetermineForAll<T>(this T[] objs, Predicate<T> condition)
  {
    foreach(var t in objs)
    {
      if(!condition(t)) return false;
    }
    return true;
  }
  public static bool DetermineForAny<T>(this T[] objs, Predicate<T> condition)
  {
    foreach(var t in objs)
    {
      if(condition(t)) return true;
    }
    return false;
  }
  public static T[] GetSorted<T>(this T[] array)
  {
    List<T> result = array.ToList();
    result.Sort();
    return result.ToArray();
  }
  public static List<T> GetSortedList<T>(this T[] array)
  {
    List<T> result = new List<T>(array);
    result.Sort();
    return result;
  }
  public static T[] GetSorted<T>(this List<T> list)
  {
    List<T> result = list;
    result.Sort();
    return result.ToArray();
  }
  public static List<T> GetSortedList<T>(this List<T> list)
  {
    List<T> result = list;
    result.Sort();
    return result;
  }
}
[Syntax("Number","Libraries","A multi-type number that converts to all numerical types other than long or decimal.","Dan Budd")]
public struct Number : IComparable<Number>, IEquatable<Number>
{
  public double dValue;
  public int iValue { get => (int)Math.Round(dValue); set => dValue = (double)value; }
  public Number(double d) => dValue = d;
  public Number(int d) => dValue = (double)d;
  public Number(uint d) => dValue = (double)d;
  public Number(byte d) => dValue = (double)d;
  public Number(sbyte d) => dValue = (double)d;
  public Number(float d) => dValue = (double)d;
  public Number(short d) => dValue = (double)d;
  public Number(ushort d) => dValue = (double)d;
  public int CompareTo(Number other) => dValue.CompareTo(other.dValue);
  public bool Equals(Number other) => dValue == other.dValue;
  public override int GetHashCode() => HashCode.Combine<double>(dValue);
  public override bool Equals(object? other) => other != null && other is Number n ? this.Equals(n) : false;
  public bool IsInteger {get  => dValue % 1.0 == 0.0;}
  public int Sign { get => Math.Sign(dValue);}
  public bool IsPositive { get => Sign == 1;}
  public bool IsNegative { get => Sign == -1;}
  public bool IsZero { get => dValue == 0.0;}
  public override string ToString() {return IsInteger ? $"{iValue}" : $"{dValue}"; }
  public static bool operator ==(Number n1, Number n2) => n1.Equals(n2);
  public static bool operator !=(Number n1, Number n2) => !n1.Equals(n2);
  public static bool operator <(Number n1, Number n2) => n1.CompareTo(n2) < 0;
  public static bool operator >(Number n1, Number n2) => n1.CompareTo(n2) > 0;
  public static bool operator >=(Number n1, Number n2) => n1.CompareTo(n2) >= 0;
  public static bool operator <=(Number n1, Number n2) => n1.CompareTo(n2) <= 0;
  public static Number operator ^(Number n1, Number n2) => Math.Pow(n1.dValue,n2.dValue);
  public static Number operator +(Number n1) => n1;
  public static Number operator +(Number n1, Number n2) => n1.dValue + n2.dValue;
  public static Number operator -(Number n) => -n.dValue;
  public static Number operator -(Number n1, Number n2) => n1.dValue - n2.dValue;
  public static Number operator *(Number n1, Number n2) => n1.dValue * n2.dValue;
  public static Number operator /(Number n1, Number n2) => n2 == 0.0 ? Double.PositiveInfinity * n1.Sign * n2.Sign : n1.dValue / n2.dValue;
  public static Number operator ++(Number n)
  {
    n.dValue += 1.0;
    return n;
  }
  public static Number operator --(Number n)
  {
    n.dValue -= 1.0;
    return n;
  }
  public static implicit operator Number(double d) => new Number(d);
  public static implicit operator Number(int d) => new Number(d);
  public static implicit operator Number(uint d) => new Number(d);
  public static implicit operator Number(short d) => new Number(d);
  public static implicit operator Number(ushort d) => new Number(d);
  public static implicit operator Number(byte d) => new Number(d);
  public static implicit operator Number(sbyte d) => new Number(d);
  public static implicit operator Number(float d) => new Number(d);
  public static implicit operator double(Number n) => n.dValue;
  public static implicit operator int(Number n) => n.iValue;
  public static implicit operator float(Number n) => (float)n.dValue;
  public static implicit operator uint(Number n) => (uint)n.iValue;
  public static implicit operator byte(Number n) => (byte)n.iValue;
  public static implicit operator sbyte(Number n) => (sbyte)n.iValue;
  public static implicit operator short(Number n) => (short)n.iValue;
  public static implicit operator ushort(Number n) => (ushort)n.iValue;
  public static implicit operator decimal(Number n) => (decimal)n.dValue;
}
public record struct Coordinate(Number x, Number y) : IComparable<Coordinate>, IEquatable<Coordinate>
{
  public Number x { get; set; } = x;
  public Number y { get; set; } = y;
  public static implicit operator Coordinate(Number y) => new Coordinate(0,y);
  public static implicit operator Coordinate((Number x, Number y) pair) => new(x: pair.x, y: pair.y);
  public int CompareTo(Coordinate c) => x.CompareTo(c.y) == 0 ? y.CompareTo(c.y) : x.CompareTo(c.x);
  public bool Equals(Coordinate other) => x == other.x && y == other.y;
  public int Quadrant{get => x.IsPositive ? y.IsPositive ? 1 : 4 : y.IsPositive ? 2 : 3;}
  public override int GetHashCode() => HashCode.Combine<Number,Number>(x,y);
  public override string ToString() => $"({x},{y})";
  public static implicit operator (Number x, Number y)(Coordinate c) => (c.x, c.y);
  public static readonly Coordinate Origin = new Coordinate(0,0);
  public static Coordinate operator +(Coordinate c) => c;
  public static Coordinate operator +(Coordinate c1, Coordinate c2) => new Coordinate(c1.x + c2.x, c1.y + c2.y);
  public static Coordinate operator -(Coordinate c) => new Coordinate(-c.x, -c.y);
  public static Coordinate operator -(Coordinate c1, Coordinate c2) => new Coordinate(c1.x - c2.x, c1.y - c2.y);
  public static Coordinate operator *(Coordinate c1, Coordinate c2) => new Coordinate(c1.x * c2.x, c1.y * c2.y);
  public static Coordinate operator /(Coordinate c1, Number scalar) => scalar != 0.0 ? new Coordinate(c1.x / scalar, c1.y / scalar) : c1;
  public static Coordinate operator *(Coordinate c1, Number scalar) => new Coordinate(c1.x * scalar, c1.y * scalar);
  public static Coordinate operator ^(Coordinate c, Number power) => new Coordinate(Math.Pow(c.x,power),Math.Pow(c.y,power));
  public static Number YSum(params Coordinate[] coordinates)
  {
    Number result = 0.0;
    foreach(var c in coordinates)
    {
      result += c.y;
    }
    return result;
  }
  public static Number XSum(params Coordinate[] coordinates)
  {
    Number result = 0.0;
    foreach(var c in coordinates)
    {
      result += c.x;
    }
    return result;
  }
  // public static 
  // public static Coordinate operator +(Coordinate c1, Coordinate c2) => new Coordinate()
}
[Obsolete("NameAttribute is useless now. Use SyntaxAttribute instead now.")]
[AttributeUsage(AttributeTargets.All,Inherited=false)]
public class NameAttribute : Attribute
{
  public string name { get; }
  public NameAttribute(string n)
  {
    name = n;
  }
}
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
[Obsolete]
public class SyntaxExistsException: Exception
{
  public SyntaxInfo Duplicate { get; }
  public SyntaxExistsException(SyntaxInfo info) : base($"{info.name} Syntax is already defined.")
  {
    Duplicate = info;
  }
  public SyntaxExistsException(SyntaxInfo info, Exception inner) : base($"{info.name} Syntax is already defined.", inner)
  {
    Duplicate = info;
  }
}
[Obsolete("DescriptionAttribute is useless now. Use SyntaxAttribute instead.")]
[AttributeUsage(AttributeTargets.All, Inherited=false)]
public class DescriptionAttribute : Attribute
{
  public string description { get; }
  public DescriptionAttribute(string descs)
  {
    description = descs;
  }
}
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
  public SyntaxAttribute(string ItemName, string Description, string Author, string[] Remarks)
  {
    name = ItemName;
    description = Description;
    author = Author;
    remarks = Remarks;
    @namespace = "Not Specified.";
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
// [Syntax("Libraries.SyntaxInfo",)]
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