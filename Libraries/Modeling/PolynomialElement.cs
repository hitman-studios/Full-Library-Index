namespace Libraries.Modeling;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
public struct PolynomialElement : IComparable<PolynomialElement>, IEquatable<PolynomialElement>
{
  public Number coefficient { get; }
  public Number exponent { get; }
  public PolynomialElement([Optional]Number Coefficient, [Optional]Number Exponent)
  {
    coefficient = Coefficient == default(Number) ? 1.0 : Coefficient;
    exponent = Exponent == default(Number) ? 1.0 : Exponent;
  }
  public Equation ToEquation()
  {
    Number coeff = coefficient;
    Number exp = exponent;
    return (x) => coeff * (x^exp);
  }
  public Number Evaluate(Number input) => ToEquation()(input);
  public int CompareTo(PolynomialElement e)
  {
    int c0 = exponent.CompareTo(e.exponent);
    return c0 == 0 ? coefficient.CompareTo(e.coefficient) : c0;
  }
  public bool Equals(PolynomialElement e)
  {
    return coefficient == e.coefficient && exponent == e.exponent;
  }
  public override bool Equals(object? other) => other != null && other is PolynomialElement e ? this.Equals(e) : false;
  public override int GetHashCode() => HashCode.Combine<Number,Number>(exponent,coefficient);
  public override string ToString() => $"{coefficient.ToString()}x^{exponent.ToString()}";
  public static implicit operator PolynomialElement((Number c, Number e) setup) => new PolynomialElement(setup.c, setup.e);
}
public sealed class Monomial
{
  public PolynomialElement element { get; }
  public Monomial(PolynomialElement e)
  {
    element = e;
  }
  public Equation ToEquation() => element.ToEquation();
  public static implicit operator Equation(Monomial m) => m.ToEquation();
}
public sealed class Polynomial
{
  public PolynomialElement[] Elements { get; }
  public Polynomial(params PolynomialElement[] elements)
  {
    Elements = elements;
  }
  public Equation ToEquation() => Elements.Pull(element => element.ToEquation()).Sum();
  public static implicit operator Equation(Polynomial p) => p.ToEquation();
}