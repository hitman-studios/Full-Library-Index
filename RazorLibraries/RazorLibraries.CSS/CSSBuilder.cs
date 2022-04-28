[assembly: TODO("FINISH BUILDER!!")]
namespace RazorLibraries.CSS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Libraries;
public sealed class CSSBuilder
{
  private bool buildable { get;}
  public CSSBuilder()
  {
    buildable = false;
    _borders = null;
  }
  private CSSBuilder(BorderSet b)
  {
    buildable = true;
    _borders = b;
  }
  public CSSBuilder WithBorders(BorderProfile a)
  {
    return new CSSBuilder(BorderSet.Create(a));
  }
  public CSSBuilder WithBorders(BorderProfile a, BorderProfile b)
  {
    return new CSSBuilder(BorderSet.Create(a,b));
  }
  public CSSBuilder WithBorders(BorderProfile a, BorderProfile b,BorderProfile c,BorderProfile d)
  {
    return new CSSBuilder(BorderSet.Create(a,b,c,d));
  }
  public sealed class BuilderInternals : IDisposable
  {
    private BorderProfile? top = null;
    private BorderProfile? right = null;
    private BorderProfile? bottom = null;
    private BorderProfile? left = null;
    internal BuilderInternals()
    {
      // 
    }
    ~BuilderInternals()
    {
      Dispose();
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    private bool _disposed = false;
    void Dispose(bool disposing)
    {
      if(_disposed) return;
      if(disposing)
      {
        // TODO: dispose managed state
      }
      top = null;
      left = null;
      right = null;
      bottom = null;
      _disposed = true;
    }
    private BuilderInternals(BorderProfile? t = null, BorderProfile? r = null, BorderProfile? b = null, BorderProfile? l = null)
    {
      top = t;
      right = r;
      bottom = b;
      left = l;
    }
    public BuilderInternals WithLeftBorder(BorderProfile left)
    {
      this.left = left;
      return this;
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width, Color color)
    {
      this.left = BorderProfile.Create(style,width,color);
      return this;
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType, Color color)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType),color));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType),Color.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType),Color.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Inherit(),Color.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Inherit(),Color.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,width,Color.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,width,Color.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Color color)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Inherit(),color));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,width,Color.Inherit()));
    }
    public BuilderInternals WithLeftBorder(Measurement m, Color c)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,c));
    }
    public BuilderInternals WithLeftBorder(Measurement m, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,Color.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(Measurement m, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,Color.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(Measurement m)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,Color.Inherit()));
    }
    public BuilderInternals WithLeftBorder(Color c)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,Measurement.Inherit(),c));
    }
    public BuilderInternals WithLeftBorder(byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,Measurement.Inherit(),Color.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,Measurement.Inherit(),Color.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder()
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Inherit());
    }
    public BuilderInternals WithRightBorder(BorderProfile right)
    {
      return new BuilderInternals(top,right,bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m, Color c) 
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,c));
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m, string hex)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,Color.HEX(hex)),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,Color.RGB(r,g,b)),bottom, left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,Color.Inherit()),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType, Color c)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,Measurement.Create(width,mType),c),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType, string hex)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,Measurement.Create(width,mType),Color.HEX(hex)),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,Measurement.Create(width,mType),Color.RGB(r,g,b)),bottom, left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType)
    {
      right = BorderProfile.Create(style,Measurement.Create(width,mType));
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Color color) 
    {
      right = BorderProfile.Create(style,Measurement.Inherit(),color);
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style, string hex) 
    {
      right = BorderProfile.Create(style, Measurement.Inherit(),Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style, byte r, byte g, byte b)
    {
      right = BorderProfile.Create(style, Measurement.Inherit(), Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style) 
    {
      right = BorderProfile.Create(style, Measurement.Inherit(), Color.Inherit());
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m, Color color)
    {
      right = BorderProfile.Create(BorderStyle.Inherit,m, color);
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m, string hex)
    {
      right = BorderProfile.Create(BorderStyle.Inherit,m,Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m, byte r, byte g, byte b)
    {
      right = BorderProfile.Create(BorderStyle.Inherit,m,Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, m);
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType, Color c)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width,mType), c);
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType, string hex)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width,mType), Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType, byte r, byte g, byte b)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width, mType), Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width,mType));
      return this;
    }
    public BuilderInternals WithRightBorder(Color color)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Inherit(), color);
      return this;
    }
    public BuilderInternals WithRightBorder(string hex)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Inherit(), Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(byte r, byte g, byte b)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Inherit(), Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder()
    {
      right = BorderProfile.Inherit();
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Measurement m, Color color)
    {
      bottom = BorderProfile.Create(style,m,color);
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Measurement m, string hex)
    {
      bottom = BorderProfile.Create(style,m,Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Measurement m, byte r, byte g, byte b)
    {
      bottom = BorderProfile.Create(style,m,Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Measurement m)
    {
      bottom = BorderProfile.Create(style,m);
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType, Color c)
    {
      bottom = BorderProfile.Create(style, Measurement.Create(width,mType),c);
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType, string hex)
    {
      bottom = BorderProfile.Create(style, Measurement.Create(width,mType),Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b)
    {
      bottom = BorderProfile.Create(style, Measurement.Create(width,mType), Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType)
    {
      bottom = BorderProfile.Create(style, Measurement.Create(width,mType));
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, Color color)
    {
      bottom = BorderProfile.Create(style, color);
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, string hex)
    {
      bottom = BorderProfile.Create(style,Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style, byte r, byte g, byte b)
    {
      bottom = BorderProfile.Create(style,Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithBottomBorder(BorderStyle style)
    {
      bottom = BorderProfile.Create(style);
      return this;
    }
    public BuilderInternals WithBottomBorder(Measurement m, Color color)
    {
      bottom = BorderProfile.Create(m,color);
      return this;
    }
    public BuilderInternals WithBottomBorder(Measurement m, string hex)
    {
      bottom = BorderProfile.Create(m,Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithBottomBorder(Measurement m, byte r, byte g, byte b)
    {
      bottom = BorderProfile.Create(m,Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithBottomBorder(Measurement m)
    {
      bottom = BorderProfile.Create(m);
      return this;
    }
    public BuilderInternals WithBottomBorder(Number width, string mType, Color c)
    {
      bottom = BorderProfile.Create(Measurement.Create(width,mType),c);
      return this;
    }
    public BuilderInternals WithBottomBorder(Number width, string mType, string hex)
    {
      bottom = BorderProfile.Create(Measurement.Create(width,mType),Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithBottomBorder(Number width, string mType, byte r, byte g, byte b)
    {
      bottom = BorderProfile.Create(Measurement.Create(width,mType),Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithBottomBorder(Number width, string mType)
    {
      bottom = BorderProfile.Create(Measurement.Create(width,mType));
      return this;
    }
    public BuilderInternals WithBottomBorder(Color color)
    {
      bottom = BorderProfile.Create(color);
      return this;
    }
    public BuilderInternals WithBottomBorder(string hex)
    {
      bottom = BorderProfile.Create(Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithBottomBorder(byte r, byte g, byte b)
    {
      bottom = BorderProfile.Create(Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithBottomBorder()
    {
      bottom = BorderProfile.Inherit();
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Measurement m, Color c)
    {
      top = BorderProfile.Create(style, m,c);
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Measurement m, string hex)
    {
      top = BorderProfile.Create(style,m,Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Measurement m, byte r, byte g, byte b)
    {
      top = BorderProfile.Create(style,m,Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Measurement m)
    {
      top = BorderProfile.Create(style,m);
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType, Color c)
    {
      top = BorderProfile.Create(style, Measurement.Create(width,mType),c);
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType, string hex)
    {
      top = BorderProfile.Create(style,Measurement.Create(width,mType),Color.HEX(hex));
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b)
    {
      top = BorderProfile.Create(style,Measurement.Create(width,mType),Color.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType)
    {
      top = BorderProfile.Create(style,Measurement.Create(width,mType));
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, Color color)
    {
      top = BorderProfile.Create(style,color);
      return this;
    }
    public BuilderInternals WithTopBorder(BorderStyle style, string hex)
    {
      return WithTopBorder(style,Color.HEX(hex));
    }
    public BuilderInternals WithTopBorder(BorderStyle style, byte r, byte g, byte b)
    {
      return WithTopBorder(style,Color.RGB(r,g,b));
    }
    public BuilderInternals WithTopBorder(BorderStyle style)
    {
      top = BorderProfile.Create(style);
      return this;
    }
    public BuilderInternals WithTopBorder(Measurement m, Color color)
    {
      top = BorderProfile.Create(m,color);
      return this;
    }
    public BuilderInternals WithTopBorder(Measurement m, string hex)
    {
      return WithTopBorder(m,Color.HEX(hex));
    }
    public BuilderInternals WithTopBorder(Measurement m, byte r, byte g, byte b)
    {
      return WithTopBorder(m,Color.RGB(r,g,b));
    }
    public BuilderInternals WithTopBorder(Measurement m)
    {
      top = BorderProfile.Create(m);
      return this;
    }
    public BuilderInternals WithTopBorder(Number width, string mType, Color c)
    {
      top = BorderProfile.Create(Measurement.Create(width,mType),c);
      return this;
    }
    public BuilderInternals WithTopBorder(Number width, string mType, string hex)
    {
      return WithTopBorder(width,mType,Color.HEX(hex));
    }
    public BuilderInternals WithTopBorder(Number width, string mType, byte r, byte g, byte b)
    {
      return WithTopBorder(width,mType,Color.RGB(r,g,b));
    }
    public BuilderInternals WithTopBorder(Number width, string mType)
    {
      return WithTopBorder(Measurement.Create(width,mType));
    }
    public BuilderInternals WithTopBorder(Color color)
    {
      top = BorderProfile.Create(color);
      return this;
    }
    public BuilderInternals WithTopBorder(string hex)
    {
      return WithTopBorder(Color.HEX(hex));
    }
    public BuilderInternals WithTopBorder(byte r, byte g, byte b)
    {
      return WithTopBorder(Color.RGB(r,g,b));
    }
    public BuilderInternals WithTopBorder()
    {
      top = BorderProfile.Inherit();
      return this;
    }
    public BuilderInternals WithTopBorder(BorderProfile top)
    {
      return new BuilderInternals(top,right,bottom,left);
    }
    public BuilderInternals WithBottomBorder(BorderProfile bottom)
    {
      return new BuilderInternals(top,right,bottom,left);
    }
    public BuilderInternals WithBorders(BorderProfile a)
    {
      top = a;
      right = a;
      bottom = a;
      left = a;
      return this;
    }
    public BuilderInternals WithBorders(BorderProfile a, BorderProfile b) {
      top = a;
      right = b;
      bottom = a;
      left = b;
      return this;
    }
    public BuilderInternals WithBorders(BorderProfile a, BorderProfile b, BorderProfile c, BorderProfile d)
    {
      top = a;
      right = b;
      bottom = c;
      left = d;
      return this;
    }
    #nullable disable
    public CSSBuilder EndCreation()
    {
      return new CSSBuilder(BorderSet.Create(top,right,bottom,left));
    }
    #nullable enable
  }
  public BuilderInternals StartCreation()
  {
    return new BuilderInternals();
  }
  private BorderSet? _borders { get; }
  public string Build()
  {
    return buildable && _borders != null ? ((BorderSet)_borders).GenerateCSS() : "border: inherit;";
  }
}