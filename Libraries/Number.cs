using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Libraries;

/**
<summary>A muli-purpose numerical value that can convert to almost any types.<br/></summary>
<remarks>Cannot convert to long, ulong, decimal, or BigInteger</remarks>
*/
[Syntax("Number","Libraries","A multi-type number that converts to and from all numerical types other than long, ulong, or decimal.","Dan Budd",
       "Cannot convert to or from these types:\nlong,\nulong,\ndecimal")]
public struct Number : IComparable<Number>, IEquatable<Number>
{
  public double dValue;
  public int iValue { get => (int)Math.Round(dValue); set => dValue = (double)value; }
  public Number(double d) => dValue = d;
  public Number(int d) => dValue = (double)d;
  public Number(uint d) => dValue = (double)d;
  public Number(byte d) => dValue = (double)d;
  public Number(sbyte d) => dValue = (double)d;
  public Number(float d) => dValue = (double)d;
  public Number(short d) => dValue = (double)d;
  public Number(ushort d) => dValue = (double)d;
  public int CompareTo(Number other) => dValue.CompareTo(other.dValue);
  public bool Equals(Number other) => dValue == other.dValue;
  public override string ToString() {return IsInteger ? $"{iValue}" : $"{dValue}"; }
  public override int GetHashCode() => HashCode.Combine<double>(dValue);
  public override bool Equals(object? other) => other != null && other is Number n ? this.Equals(n) : false;
  public bool IsInteger {get  => dValue % 1.0 == 0.0;}
  public int Sign { get => Math.Sign(dValue);}
  public bool IsPositive { get => Sign == 1;}
  public bool IsNegative { get => Sign == -1;}
  public bool IsZero { get => dValue == 0.0;}
  public static Number Sum(params Number[] ns)
  {
    Number result = 0.0;
    foreach(var n in ns) { result += n; }
    return result;
  }
  public static bool operator ==(Number n1, Number n2) => n1.Equals(n2);
  public static bool operator !=(Number n1, Number n2) => !n1.Equals(n2);
  public static bool operator <(Number n1, Number n2) => n1.CompareTo(n2) < 0;
  public static bool operator >(Number n1, Number n2) => n1.CompareTo(n2) > 0;
  public static bool operator >=(Number n1, Number n2) => n1.CompareTo(n2) >= 0;
  public static bool operator <=(Number n1, Number n2) => n1.CompareTo(n2) <= 0;
  public static Number operator ^(Number n1, Number n2) => Math.Pow(n1.dValue,n2.dValue);
  public static Number operator +(Number n1) => n1;
  public static Number operator +(Number n1, Number n2) => n1.dValue + n2.dValue;
  public static Number operator -(Number n) => -n.dValue;
  public static Number operator -(Number n1, Number n2) => n1.dValue - n2.dValue;
  public static Number operator *(Number n1, Number n2) => n1.dValue * n2.dValue;
  public static Number operator /(Number n1, Number n2) => n2 == 0.0 ? Double.PositiveInfinity * n1.Sign * n2.Sign : n1.dValue / n2.dValue;
  public static Number operator ++(Number n)
  {
    n.dValue += 1.0;
    return n;
  }
  public static Number operator --(Number n)
  {
    n.dValue -= 1.0;
    return n;
  }
  public static implicit operator Number(double d) => new Number(d);
  public static implicit operator Number(int d) => new Number(d);
  public static implicit operator Number(uint d) => new Number(d);
  public static implicit operator Number(short d) => new Number(d);
  public static implicit operator Number(ushort d) => new Number(d);
  public static implicit operator Number(byte d) => new Number(d);
  public static implicit operator Number(sbyte d) => new Number(d);
  public static implicit operator Number(float d) => new Number(d);
  public static implicit operator double(Number n) => n.dValue;
  public static implicit operator int(Number n) => n.iValue;
  public static implicit operator float(Number n) => (float)n.dValue;
  public static implicit operator uint(Number n) => (uint)n.iValue;
  public static implicit operator byte(Number n) => (byte)n.iValue;
  public static implicit operator sbyte(Number n) => (sbyte)n.iValue;
  public static implicit operator short(Number n) => (short)n.iValue;
  public static implicit operator ushort(Number n) => (ushort)n.iValue;
  public static implicit operator decimal(Number n) => (decimal)n.dValue;
}