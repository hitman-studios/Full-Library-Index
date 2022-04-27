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
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width, BorderColor color)
    {
      this.left = BorderProfile.Create(style,width,color);
      return this;
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType, BorderColor color)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType),color));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType),BorderColor.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType),BorderColor.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Number width, string mType)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Create(width,mType)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Inherit(),BorderColor.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Inherit(),BorderColor.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,width,BorderColor.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,width,BorderColor.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, BorderColor color)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,Measurement.Inherit(),color));
    }
    public BuilderInternals WithLeftBorder(BorderStyle style, Measurement width)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(style,width,BorderColor.Inherit()));
    }
    public BuilderInternals WithLeftBorder(Measurement m, BorderColor c)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,c));
    }
    public BuilderInternals WithLeftBorder(Measurement m, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,BorderColor.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(Measurement m, string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,BorderColor.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder(Measurement m)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,m,BorderColor.Inherit()));
    }
    public BuilderInternals WithLeftBorder(BorderColor c)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,Measurement.Inherit(),c));
    }
    public BuilderInternals WithLeftBorder(byte r, byte g, byte b)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,Measurement.Inherit(),BorderColor.RGB(r,g,b)));
    }
    public BuilderInternals WithLeftBorder(string hex)
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Create(BorderStyle.Inherit,Measurement.Inherit(),BorderColor.HEX(hex)));
    }
    public BuilderInternals WithLeftBorder()
    {
      return new BuilderInternals(top,right,bottom,BorderProfile.Inherit());
    }
    public BuilderInternals WithRightBorder(BorderProfile right)
    {
      return new BuilderInternals(top,right,bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m, BorderColor c) 
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,c));
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m, string hex)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,BorderColor.HEX(hex)),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,BorderColor.RGB(r,g,b)),bottom, left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Measurement m)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,m,BorderColor.Inherit()),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType, BorderColor c)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,Measurement.Create(width,mType),c),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType, string hex)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,Measurement.Create(width,mType),BorderColor.HEX(hex)),bottom,left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b)
    {
      return new BuilderInternals(top,BorderProfile.Create(style,Measurement.Create(width,mType),BorderColor.RGB(r,g,b)),bottom, left);
    }
    public BuilderInternals WithRightBorder(BorderStyle style, Number width, string mType)
    {
      right = BorderProfile.Create(style,Measurement.Create(width,mType));
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style, BorderColor color) 
    {
      right = BorderProfile.Create(style,Measurement.Inherit(),color);
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style, string hex) 
    {
      right = BorderProfile.Create(style, Measurement.Inherit(),BorderColor.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style, byte r, byte g, byte b)
    {
      right = BorderProfile.Create(style, Measurement.Inherit(), BorderColor.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder(BorderStyle style) 
    {
      right = BorderProfile.Create(style, Measurement.Inherit(), BorderColor.Inherit());
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m, BorderColor color)
    {
      right = BorderProfile.Create(BorderStyle.Inherit,m, color);
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m, string hex)
    {
      right = BorderProfile.Create(BorderStyle.Inherit,m,BorderColor.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m, byte r, byte g, byte b)
    {
      right = BorderProfile.Create(BorderStyle.Inherit,m,BorderColor.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder(Measurement m)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, m);
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType, BorderColor c)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width,mType), c);
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType, string hex)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width,mType), BorderColor.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType, byte r, byte g, byte b)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width, mType), BorderColor.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder(Number width, string mType)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Create(width,mType));
      return this;
    }
    public BuilderInternals WithRightBorder(BorderColor color)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Inherit(), color);
      return this;
    }
    public BuilderInternals WithRightBorder(string hex)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Inherit(), BorderColor.HEX(hex));
      return this;
    }
    public BuilderInternals WithRightBorder(byte r, byte g, byte b)
    {
      right = BorderProfile.Create(BorderStyle.Inherit, Measurement.Inherit(), BorderColor.RGB(r,g,b));
      return this;
    }
    public BuilderInternals WithRightBorder()
    {
      right = BorderProfile.Inherit();
      return this;
    }
    // public BuilderInternals WithBottomBorder(BorderStyle style, Measurement m, string hex){}
    // public BuilderInternals WithBottomBorder(BorderStyle style, Measurement m, byte r, byte g, byte b){}
    // public BuilderInternals WithBottomBorder(BorderStyle style, Measurement m){}
    // public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType, BorderColor c){}
    // public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType, string hex){}
    // public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b){}
    // public BuilderInternals WithBottomBorder(BorderStyle style, Number width, string mType){}
    // public BuilderInternals WithBottomBorder(BorderStyle style, BorderColor color) {}
    // public BuilderInternals WithBottomBorder(BorderStyle style, string hex) {}
    // public BuilderInternals WithBottomBorder(BorderStyle style, byte r, byte g, byte b) {}
    // public BuilderInternals WithBottomBorder(BorderStyle style) {}
    // public BuilderInternals WithBottomBorder(Measurement m, BorderColor color){}
    // public BuilderInternals WithBottomBorder(Measurement m, string hex){}
    // public BuilderInternals WithBottomBorder(Measurement m, byte r, byte g, byte b){}
    // public BuilderInternals WithBottomBorder(Measurement m){}
    // public BuilderInternals WithBottomBorder(Number width, string mType, BorderColor c){}
    // public BuilderInternals WithBottomBorder(Number width, string mType, string hex){}
    // public BuilderInternals WithBottomBorder(Number width, string mType, byte r, byte g, byte b){}
    // public BuilderInternals WithBottomBorder(Number width, string mType){}
    // public BuilderInternals WithBottomBorder(BorderColor color) {}
    // public BuilderInternals WithBottomBorder(string hex) {}
    // public BuilderInternals WithBottomBorder(byte r, byte g, byte b) {}
    // public BuilderInternals WithBottomBorder() {}
    // public BuilderInternals WithTopBorder(BorderStyle style, Measurement m, string hex){}
    // public BuilderInternals WithTopBorder(BorderStyle style, Measurement m, byte r, byte g, byte b){}
    // public BuilderInternals WithTopBorder(BorderStyle style, Measurement m){}
    // public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType, BorderColor c){}
    // public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType, string hex){}
    // public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType, byte r, byte g, byte b){}
    // public BuilderInternals WithTopBorder(BorderStyle style, Number width, string mType){}
    // public BuilderInternals WithTopBorder(BorderStyle style, BorderColor color) {}
    // public BuilderInternals WithTopBorder(BorderStyle style, string hex) {}
    // public BuilderInternals WithTopBorder(BorderStyle style, byte r, byte g, byte b) {}
    // public BuilderInternals WithTopBorder(BorderStyle style) {}
    // public BuilderInternals WithTopBorder(Measurement m, BorderColor color){}
    // public BuilderInternals WithTopBorder(Measurement m, string hex){}
    // public BuilderInternals WithTopBorder(Measurement m, byte r, byte g, byte b){}
    // public BuilderInternals WithTopBorder(Measurement m){}
    // public BuilderInternals WithTopBorder(Number width, string mType, BorderColor c){}
    // public BuilderInternals WithTopBorder(Number width, string mType, string hex){}
    // public BuilderInternals WithTopBorder(Number width, string mType, byte r, byte g, byte b){}
    // public BuilderInternals WithTopBorder(Number width, string mType){}
    // public BuilderInternals WithTopBorder(BorderColor color) {}
    // public BuilderInternals WithTopBorder(string hex) {}
    // public BuilderInternals WithTopBorder(byte r, byte g, byte b) {}
    // public BuilderInternals WithTopBorder() {}
    public BuilderInternals WithTopBorder(BorderProfile top)
    {
      return new BuilderInternals(top,right,bottom,left);
    }
    public BuilderInternals WithBottomBorder(BorderProfile bottom)
    {
      return new BuilderInternals(top,right,bottom,left);
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