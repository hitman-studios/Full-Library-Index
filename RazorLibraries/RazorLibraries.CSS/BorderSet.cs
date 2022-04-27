namespace RazorLibraries.CSS;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
/**
<summary>The built class for the <see cref="CSSBuilder"/></summary>
<remarks> This class has no public constructor. <br/>
<para>
To create one, you use the static Create method with 1, 2, or 4 <see cref="BorderProfile"/> parameters.
</para>



</remarks>
*/
public sealed class BorderSet : IComponentStyle
{
  private List<Border> Borders = new List<Border>(4);
  private string preset { get; }
  private BorderSet()
  {
    preset = "inherit";
  }
  private BorderSet(string preset)
  {
    this.preset = preset;
  }
  private BorderSet(Border a) {
    this.preset = "normal";
    Borders.Add(a);
  }
  private BorderSet(Border a, Border b) {
    this.preset = "normal";
    Borders.Add(a);
    Borders.Add(b);
  }
  private BorderSet(Border a, Border b, Border c, Border d) {
    this.preset = "normal";
    Borders.Add(a);
    Borders.Add(b);
    Borders.Add(c);
    Borders.Add(d);
  }
  private BorderSet(BorderProfile? a, BorderProfile? b, BorderProfile? c, BorderProfile? d)
  {
    this.preset = "normal";
    if(a != null) Borders.Add(new(Profile: (BorderProfile)a, Sides: BorderSides.Top));
    if(b != null) Borders.Add(new(Profile: (BorderProfile)b, Sides: BorderSides.Right));
    if(c != null) Borders.Add(new(Profile: (BorderProfile)c, Sides: BorderSides.Bottom));
    if(d != null) Borders.Add(new(Profile: (BorderProfile)d, Sides: BorderSides.Left));
  }
  private BorderSet(BorderProfile all)
  {
    this.preset = "normal";
    Borders.Add(new(Profile: all, Sides: BorderSides.All));
  }
  private BorderSet(BorderProfile h, BorderProfile v)
  {
    preset = "normal";
    Borders.Add(new(Profile: h, Sides: BorderSides.Horizontal));
    Borders.Add(new(Profile: v, Sides: BorderSides.Vertical));
  }
/**
*/
  public static BorderSet Create(BorderProfile pAll)
  {
    return new BorderSet(pAll);
  }
/**
*/
  public static BorderSet Create(BorderProfile p1, BorderProfile p2)
  {
    return new BorderSet(p1,p2);
  }
/**
*/
  public static BorderSet Create(BorderProfile p1, BorderProfile p2, BorderProfile p3, BorderProfile p4)
  {
    return new BorderSet(p1,p2,p3,p4);
  }
/**
*/
  public static BorderSet Create(Border a)
  {
    return new BorderSet(a);
  }
/**
*/
  public static BorderSet Create(Border a, Border b)
  {
    return new BorderSet(a,b);
  }
/**
*/
  public static BorderSet Create(Border a, Border b, Border c, Border d)
  {
    return new BorderSet(a,b,c,d);
  }
/**
*/
  internal static BorderSet CreateWithNullables(BorderProfile? a, BorderProfile? b, BorderProfile? c, BorderProfile? d)
  {
    return new BorderSet(a,b,c,d);
  }
/**
*/
  public string GenerateCSS()
  {
    string result = "";
    foreach(Border[] bSet in Borders.GetSortedList().ToArray().Pull(b => b.SeparateBorders()).GetSorted())
    {
      foreach(Border border in bSet.GetSorted())
      {
        result += border.GenerateCSS();
      }
    }
    return result;
  }
/**
*/
  public bool HasBorders => Borders.Count > 0;
/**
*/
  public bool IsInherit => false;
/**
*/
  public bool IsInitial => false;
}
/**
*/
public record struct Border(BorderProfile Profile, BorderSides Sides) : IComparable<Border>, IEquatable<Border>, IComponentStyle
{
/**
*/
  public BorderProfile Profile { get; private set; } = Profile;
/**
*/
  public BorderSides Sides { get; private set; } = Sides == BorderSides.None ? BorderSides.All : Sides;
/**
*/
  public int BorderCount => Sides.Count();
/**
*/
  public Border[] SeparateBorders()
  {
    List<Border> output = new List<Border>();
    foreach(BorderSides side in SeparateSides())
    {
      output.Add(new(Profile: this.Profile, Sides: side));
    }
    return output.ToArray();
  }
/**
*/
  public BorderSides[] SeparateSides() => Sides.GetSides();
/**
*/
  [TODO("ADD ALL BorderProfile constructors.")]
  public Border SetProfile(BorderStyle style, Measurement m, BorderColor color)
  {
    Profile = Profile.SetStyle(style).SetWidth(m).SetColor(color);
    return this;
  }
/**
*/
  public Border SetWidth(Measurement m)
  {
    Profile.SetWidth(m);
    return this;
  }
/**
*/
  public Border SetColor(BorderColor c)
  {
    Profile.SetColor(c);
    return this;
  }
/**
*/
  public Border SetStyle(BorderStyle s)
  {
    Profile.SetStyle(s);
    return this;
  }
/**
*/
  public Border SetSides(BorderSides s)
  {
    Sides = s != BorderSides.None ? s : BorderSides.All;
    return this;
  }
/**
*/
  public int CompareTo(Border other)
  {
    int c0 = Sides.CompareTo(other.Sides);
    return c0 == 0 ? Profile.CompareTo(other.Profile) : c0;
  }
/**
*/
  public bool Equals(Border other)
  {
    return CompareTo(other) == 0;
  }
/**
*/
  public static Border Inherit(BorderSides sides = BorderSides.All)
  {
    return new(Profile: BorderProfile.Inherit(),Sides: sides != BorderSides.None ? sides : BorderSides.All);
  }
/**
*/
  public string GenerateCSS() => $"border-{Sides.ToString().ToLower()}: {Profile.GenerateCSS()};";
/**
*/
  public override int GetHashCode() => HashCode.Combine<BorderProfile,BorderSides>(Profile,Sides);
/**
*/
  public bool IsInherit => Profile.IsInherit;
/**
*/
  public bool IsInitial => Profile.IsInitial;
  public static explicit operator BorderProfile(Border b) => b.Profile;
  public static implicit operator Border((BorderProfile p, BorderSides s) setup) => new Border(setup.p, setup.s);
}