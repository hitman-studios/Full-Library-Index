using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
/**
<summary>Declares what needs to be done. Should be paired with <see cref="WIPAttribute"/></summary>
<remarks><c>AllowMultiple=true</c>, <c>Inherited=false</c></remarks>
*/
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited=false)]
public sealed class TODOAttribute : Attribute
{
  private static List<string> _messages = new List<string>();
  public static string[] GetMessages() => _messages.ToArray();
  public string message { get; }
  public TODOAttribute(string msg)
  {
    message = msg;
    _messages.Add($"TODO: {msg}");
  }
  public static void DisplayAll()
  {
    foreach(string todo in _messages.GetSortedList())
    {
      Console.WriteLine(todo);
    }
  }
}