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
  public static bool PrintSyntax<In>(this In obj)
  {
    return PrintSyntax<In>();
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
// [Syntax("Libraries.SyntaxInfo",)]