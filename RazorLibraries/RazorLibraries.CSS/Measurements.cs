namespace RazorLibraries.CSS;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
public static class Measurements
{
  private static readonly string[] AbsoluteLengths = new string[]{
    "cm","mm","in","px","pt","pc"
  };
  private static readonly string[] RelativeLengths = new string[]{
    "em","ex","ch","rem","vw","vh","vmin","vmax","%"
  };
  public static bool IsRelativeMeasurement(this string s) => RelativeLengths.Contains(s);
  public static bool IsAbsoluteMeasurement(this string s) => AbsoluteLengths.Contains(s);
  public static bool IsMeasurement(this string s)
  {
    return AbsoluteLengths.Contains(s) || RelativeLengths.Contains(s);
  }
  public static Measurement CreateMeasurement(this Number n, string s)
  {
    return Measurement.Create(n,s);
  }
  public static bool EqualsAny<T>(this T obj, params T[] objs)
  {
    foreach(T item in objs)
    {
      if(obj != null && item != null && obj.Equals(item)) return true;
      else continue;
    }
    return false;
  }
  public static bool Matches(this BorderSides side, BorderSides other) => (side & other) != 0;
  public static int Count(this BorderSides sides)
  {
    int result = 0;
    if(sides.Matches(BorderSides.Left)) result++;
    if(sides.Matches(BorderSides.Top)) result++;
    if(sides.Matches(BorderSides.Right)) result++;
    if(sides.Matches(BorderSides.Bottom)) result++;
    return result;
  }
  public static int Count(this BorderSides sides, out BorderSides[] output)
  {
    List<BorderSides> op = new List<BorderSides>();
    int result = 0;
    if(sides.Matches(BorderSides.Left)) {result++;op.Add(BorderSides.Left);}
    if(sides.Matches(BorderSides.Top)) {result++; op.Add(BorderSides.Top);}
    if(sides.Matches(BorderSides.Right)) {result++; op.Add(BorderSides.Right);}
    if(sides.Matches(BorderSides.Bottom)) {result++; op.Add(BorderSides.Bottom);}
    output = op.ToArray();
    return result;
  }
  public static BorderSides[] GetSides(this BorderSides sides)
  {
    List<BorderSides> output = new List<BorderSides>();
    if(sides.Matches(BorderSides.Left)) output.Add(BorderSides.Left);
    if(sides.Matches(BorderSides.Top))  output.Add(BorderSides.Top);
    if(sides.Matches(BorderSides.Right)) output.Add(BorderSides.Right);
    if(sides.Matches(BorderSides.Bottom)) output.Add(BorderSides.Bottom);
    return output.ToArray();
  }
}