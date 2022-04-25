using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
[WIP]
[TODO("Add documentation.")]
public static class Extensions
{
  #nullable disable
/**
<summary></summary>
<typeparam name="T">The type of Array to search through</typeparam>
<param name="array">The array to search through</param>
<param name="condition">The condition to use to search for the item</param>
<returns>If the search is successful, it returns the value, else the default value for T</returns>
*/
  public static T Find<T>(this T[] array, Predicate<T> condition) => array.ToList().Find(condition);
  [TODO("Add documentation.")]
  public static bool TryFind<T>(this T[] array, Predicate<T> condition, out T retValue)
  {
    T result = array.Find(condition);
    bool output = result.Equals(default(T));
    retValue = result;
    return output;
  }
  [TODO("ADD DOCUMENTATION")]
  public static string ToString(this INumber i, int @base)
  {
    return i.ToNumber().ToString(@base);
  }
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this int i) => (Number)i;
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this uint i) => (Number)i;
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this short i) => (Number)i;
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this ushort i) => (Number)i;
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this byte i) => (Number)i;
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this sbyte i) => (Number)i;
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this float i) => (Number)i;
  [TODO("ADD DOCUMENTATION")]
  public static Number ToNumber(this double i) => (Number)i;
/**
<summary>Creates a new DataEntry<Value> with the default value for "Value"</summary>
<typeparam name="Value">The Value to hold</typeparam>
<param name="key">The key for the dataEntry</param>
<returns>A new DataEntry<Value></returns>
*/
  public static DataEntry<Value> ToDataEntry<Value>(this string key)
  {
    return new DataEntry<Value>(key);
  }
  #nullable enable
/**
<summary></summary>
<typeparam name="Value">The type of value to hold in the data entry</typeparam>
<param name="pair">The (string,Value) valuetuple to convert to a dataEntry</param>
<returns>A new DataEntry<Value></returns>
*/
  public static DataEntry<Value> ToDataEntry<Value>(this (string key, Value value_) pair) => new DataEntry<Value>(pair.key, pair.value_);
  [TODO("Add documentation.")]
  internal static void Log(string message)
  {
    Console.WriteLine(message);
  }
  [TODO("Add documentation.")]
  public static bool TryGetCustomAttribute<In,Attr>(out Attr? attr) where Attr : Attribute
  {
    var attributes = (Attr[])typeof(In).GetCustomAttributes(typeof(Attr),true);
    bool output = attributes.Length > 0;
    attr = output ? attributes[0] : default(Attr);
    return true;
  }
  [TODO("Add documentation.")]
  public static bool TryGetSyntax<T>(out SyntaxInfo? i)
  {
    SyntaxAttribute? synAttr;
    bool output = TryGetCustomAttribute<T,SyntaxAttribute>(out synAttr);
    i = synAttr != null ? ((SyntaxAttribute)synAttr).GetSyntax() : null;
    return output;
  }
/**
<summary></summary>
*/
  public static Out[] Pull<In,Out>(this In[] list, Func<In,Out> m)
  {
    List<Out> output = new List<Out>();
    foreach(In i in list)
    {
      output.Add(m(i));
    }
    return output.ToArray();
  }
  [TODO("Add documentation.")]
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
  [TODO("Add documentation.")]
  public static bool TryGetCustomAttribute<In,Out>(this In obj, out Out? retValue) where Out : Attribute
  {
    var customAttr = (Out[])typeof(In).GetCustomAttributes(typeof(Out),true);
    bool output = customAttr.Length > 0;
    retValue = output ? customAttr[0] : default(Out);
    return output;
  }
  [TODO("Add documentation.")]
  public static Out? GetCustomAttribute<In,Out>(this In obj) where Out : Attribute
  {
    var customAttr = (Out[])typeof(In).GetCustomAttributes(typeof(Out),true);
    bool output = customAttr.Length > 0;
    return output ? customAttr[0] : default(Out);
  }
  [TODO("Add documentation.")]
  public static Out[]? GetAllCustomAttributes<In,Out>(this In obj) where Out : Attribute
  {
    var customAttr = (Out[])typeof(In).GetCustomAttributes(typeof(Out),true);
    bool output = customAttr.Length > 0;
    return output ? customAttr : null;
  }
  [TODO("Add documentation.")]
  public static bool TryGetSyntax<In>(this In obj, out SyntaxInfo? info)
  {
    SyntaxAttribute? synAttr;
    bool output = obj.TryGetCustomAttribute(out synAttr);
    info = output && synAttr != null ? synAttr.GetSyntax() : null;
    return output;
  }
  [TODO("Add documentation.")]
  public static bool PrintSyntax<In>()
  {
    SyntaxInfo? info;
    bool output = TryGetSyntax<In>(out info);
    Console.WriteLine(info != null ? ((SyntaxInfo)info).GenerateOutput() : "No Syntax Provided.");
    return output;
  }
  [TODO("Add documentation.")]
  public static bool PrintSyntax<In>(this In obj)
  {
    return PrintSyntax<In>();
  }
  [TODO("Add documentation.")]
  public static SyntaxInfo GetSyntax<In>(this In obj)
  {
    SyntaxAttribute? synAttr;
    bool output = obj.TryGetCustomAttribute(out synAttr);
    return output && synAttr != null ? synAttr.GetSyntax() : default(SyntaxInfo);
  }
  [TODO("Add documentation.")]
  public static Number Sum(this Number[] numbers)
  {
    Number result = 0.0;
    foreach(Number n in numbers)
    {
      result += n;
    }
    return result;
  }
  [TODO("Add documentation.")]
  public static bool DetermineForAll<T>(this T[] objs, Predicate<T> condition)
  {
    foreach(var t in objs)
    {
      if(!condition(t)) return false;
    }
    return true;
  }
  [TODO("Add documentation.")]
  public static bool DetermineForAny<T>(this T[] objs, Predicate<T> condition)
  {
    foreach(var t in objs)
    {
      if(condition(t)) return true;
    }
    return false;
  }
  [TODO("Add documentation.")]
  public static T[] GetSorted<T>(this T[] array)
  {
    List<T> result = array.ToList();
    result.Sort();
    return result.ToArray();
  }
  [TODO("Add documentation.")]
  public static List<T> GetSortedList<T>(this T[] array)
  {
    List<T> result = new List<T>(array);
    result.Sort();
    return result;
  }
  [TODO("Add documentation.")]
  public static T[] GetSorted<T>(this List<T> list)
  {
    List<T> result = list;
    result.Sort();
    return result.ToArray();
  }
  [TODO("Add documentation.")]
  public static List<T> GetSortedList<T>(this List<T> list)
  {
    List<T> result = list;
    result.Sort();
    return result;
  }
  [TODO("Add documentation.")]
  public static void DisplayTODOs<T>(this T obj)
  {
    TODOAttribute.DisplayAll();
  }
}
// [Syntax("Libraries.SyntaxInfo",)]