using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;
/**
<summary>Holds both a x and y Number value.</summary>
<remarks>



</remarks>
*/
[Syntax("Coordinate","Libraries","A record struct that holds both x and y value.", "Dan Budd")]
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
}