namespace RazorLibraries.CSS;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
public sealed class Margin : IComponentStyle
{
  public Measurement width { get; set; }
  private Margin(Measurement w)
  {
    width = w;
  }
  public static Margin Create(Measurement w) => new Margin(w);
  public static Margin Inherit() => new Margin(Measurement.Inherit());
  public static Margin Initial() => new Margin(Measurement.Initial());
  public bool IsInherit => width.IsInherit;
  public bool IsInitial => width.IsInitial;
  public string GenerateCSS() => width.GenerateCSS();
  // public 
}