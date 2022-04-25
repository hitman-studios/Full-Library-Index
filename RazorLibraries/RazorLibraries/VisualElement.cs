namespace RazorLibraries;
using System;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
public partial class VisualElement : ComponentBase
{
  protected string? ClassStyle { get; set; } = null;
  protected bool HasClass => ClassStyle != null;
  protected void SetClass(string? newClassData)
  {
    ClassStyle = newClassData;
  }
  // protected 
}