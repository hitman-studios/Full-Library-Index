namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
public static class mExtensions
{
/**
<summary>Modifies an equation with the given modifier.</summary>
<param name="equation">the equation to modify</param>
<param name="multiMod">The modifier to synthesize the result with.<br/>
Compatible modifiers are:
<list style="bullet">
<item>
<term><c>"^"</c></term>
<description>Raises the first term by the second.</description>
</item>
<item>
<term><c>"nRoot"</c></term>
<description>takes the root of the first term by the second term aka to the (1/n)th power</description>
</item>
<item>
<term><c>"nLog"</c></term>
<description>takes the log of the first term to the base of the second term.</description>
</item>
<item>
<term>Other Modifiers</term>
<description> <c>"+"</c>, <c>"-"</c>, <c>"*"</c>, <c>"/"</c>, <c>"//"</c>, <c>"%"</c> </description>
</item>
</list></param>
<param name="other">the second equation to pass into the function</param>
<returns>the synthesized equation</returns>
<remarks>
</remarks>

*/
  public static Equation Modify(this Equation equation, string multiMod, Equation other)
  {
    switch(multiMod)
    {
      case "^":
        return (n) => equation(n)^other(n);
      case "nRoot":
        return (n) => Math.Pow(equation(n),1.0/other(n));
      case "nLog":
        return (n) => Math.Log(equation(n),other(n));
      case "+":
        return (n) => equation(n) + other(n);
      case "-":
        return (n) => equation(n) - other(n);
      case "*":
        return (n) => equation(n) * other(n);
      case "/":
        return (n) => equation(n) / other(n);
      case "//":
        return (n) => Math.Floor((double)(equation(n) / other(n)));
      case "%":
        return (n) => equation(n) % other(n);
      default:
        throw new InvalidOperationException("Modifier doesn\'t exist.");
    }
  }
  public static Equation CreateEquation(this Number number, string multiMod, Equation equation)
  {
    return number.ToEquation().Modify(multiMod,equation);
  }
  /**
<summary>Creates an equation from the number and modifier.</summary>
<param name="Number">The number to create an equation from</param>
<param name="soloMod">The modifier for the number. <br/>
Compatible modifiers are:
<list style="bullet">
<item>
<term><c>"e^"</c></term>
<description>creates an equation raising e to the given number</description>
</item>
<item>
<term><c>"Ln"</c></term>
<description>takes the natural log of the number</description>
</item>
<item>
<term><c>"Log"</c></term>
<description>takes the log (with base 10) of the number</description>
</item>
<item>
<term><c>"-"</c></term>
<description>flips the sign of the number</description>
</item>
<item>
<term><c>"abs"</c></term>
<description>takes the absolute value of the number</description>
</item>
<item>
<term><c>"sqrt"</c></term>
<description>takes the square root of the number</description>
</item>
<item>
<term><c>"^2"</c></term>
<description>squares the number</description>
</item>
<item>
<term><c>"^3"</c></term>
<description>cubes the number</description>
</item>
<item>
<term><c>"^-1"</c></term>
<description>takes the reciprocal of the number</description>
</item>
<item>
<term><c>"sin"</c></term>
<description>takes the sine of the number</description>
</item>
<item>
<term><c>"cos"</c></term>
<description>takes the cosine of the number</description>
</item>
<item>
<term><c>"tan"</c></term>
<description> takes the tangent of the number</description>
</item>
<item>
<term><c>"sin^-1"</c></term>
<description> takes the inverse sine of the number</description>
</item>
<item>
<term><c>"cos^-1"</c></term>
<description> takes the inverse cosine of the number</description>
</item>
<item>
<term><c>"tan^-1"</c></term>
<description>takes the inverse tangent of the number</description>
</item>
<item>
<term><c>"sec"</c></term>
<description> takes the secant of the number</description>
</item>
<item>
<term><c>"csc"</c></term>
<description> takes the cosecant of the number</description>
</item>
<item>
<term><c>"cot"</c></term>
<description>takes the cotangent of the number</description>
</item>
<item>
<term><c>"sec^-1"</c></term>
<description>takes the inverse secant of the number</description>
</item>
<item>
<term><c>"csc^-1"</c></term>
<description>takes the inverse cosecant of the number</description>
</item>
<item>
<term><c>"cot^-1"</c></term>
<description>takes the inverse cotangent of the number</description>
</item>
<item>
<term><c>"^x"</c></term>
<description>creates a synthesized equation raising the given number to the independant variable</description>
</item>
<item>
<term><c>"x^"</c></term>
<description>creates a synthesized equation raising the independant variable to the number</description>
</item>
</list>
</param>
<returns>A synthesized equation</returns>
*/
  public static Equation CreateEquation(this Number number, string soloMod)
  {
    return number.ToEquation().Modify(soloMod);
  }
/**
<summary>Modifies an equation with the given modifier.</summary>
<param name="equation">the equation to modify</param>
<param name="multiMod">the modifier that is used to synthesize the equation<br/>
Compatible modifiers are:
<list style="bullet">
<item>
<term><c>"^"</c></term>
<description>Raises the first term by the second.</description>
</item>
<item>
<term><c>"nRoot"</c></term>
<description>takes the root of the first term by the second term aka to the (1/n)th power</description>
</item>
<item>
<term><c>"nLog"</c></term>
<description>takes the log of the first term to the base of the second term.</description>
</item>
<item>
<term>Other Modifiers</term>
<description> <c>"+"</c>, <c>"-"</c>, <c>"*"</c>, <c>"/"</c>, <c>"//"</c>, <c>"%"</c> </description>
</item>
</list></param>
<param name="other">the second equation/number that is used to create the result</param>
<returns>The modified equation</returns>
<remarks>
</remarks>

*/
  public static Equation Modify(this Equation equation, string multiMod, Number other)
  {
    return equation.Modify(multiMod,other.ToEquation());
  }
/**
<summary>Creates an equation from a number</summary>
*/
  public static Equation ToEquation(this Number n) => (x) => n;
/**
<summary>Creates a modified version of the given equation.</summary>
<param name="equation">The equation to modify</param>
<param name="soloMod">The modifier for the equation. <br/>
Compatible modifiers are:
<list style="bullet">
<item>
<term><c>"e^"</c></term>
<description>creates an equation raising e to the given equation</description>
</item>
<item>
<term><c>"Ln"</c></term>
<description>takes the natural log of the equation</description>
</item>
<item>
<term><c>"Log"</c></term>
<description>takes the log (with base 10) of the equation</description>
</item>
<item>
<term><c>"-"</c></term>
<description>flips the sign of the equation</description>
</item>
<item>
<term><c>"abs"</c></term>
<description>takes the absolute value of the equation</description>
</item>
<item>
<term><c>"sqrt"</c></term>
<description>takes the square root of the equation</description>
</item>
<item>
<term><c>"^2"</c></term>
<description>squares the equation</description>
</item>
<item>
<term><c>"^3"</c></term>
<description>cubes the equation</description>
</item>
<item>
<term><c>"^-1"</c></term>
<description>takes the reciprocal of the equation</description>
</item>
<item>
<term><c>"sin"</c></term>
<description>takes the sine of the equation</description>
</item>
<item>
<term><c>"cos"</c></term>
<description>takes the cosine of the equation</description>
</item>
<item>
<term><c>"tan"</c></term>
<description> takes the tangent of the equation</description>
</item>
<item>
<term><c>"sin^-1"</c></term>
<description> takes the inverse sine of the equation</description>
</item>
<item>
<term><c>"cos^-1"</c></term>
<description> takes the inverse cosine of the equation</description>
</item>
<item>
<term><c>"tan^-1"</c></term>
<description>takes the inverse tangent of the equation</description>
</item>
<item>
<term><c>"sec"</c></term>
<description> takes the secant of the equation</description>
</item>
<item>
<term><c>"csc"</c></term>
<description> takes the cosecant of the equation</description>
</item>
<item>
<term><c>"cot"</c></term>
<description>takes the cotangent of the equation</description>
</item>
<item>
<term><c>"sec^-1"</c></term>
<description>takes the inverse secant of the equation</description>
</item>
<item>
<term><c>"csc^-1"</c></term>
<description>takes the inverse cosecant of the equation</description>
</item>
<item>
<term><c>"cot^-1"</c></term>
<description>takes the inverse cotangent of the equation</description>
</item>
<item>
<term><c>"^x"</c></term>
<description>creates a synthesized equation raising the given equation to the independant variable</description>
</item>
<item>
<term><c>"x^"</c></term>
<description>creates a synthesized equation raising the independant variable to the equation</description>
</item>
</list>
</param>
*/
  public static Equation Modify(this Equation equation, string soloMod)
  {
    switch(soloMod)
    {
      case "e^":
        return (n) => Math.Pow(Math.E, equation(n));
      case "Ln":
        return (n) => Math.Log(equation(n));
      case "Log":
        return (n) => Math.Log10(equation(n));
      case "-":
        return (n) => -equation(n);
      case "abs":
        return (n) => Math.Abs(equation(n));
      case "sqrt":
        return (n) => equation(n)^0.5;
      case "^2":
        return (n) => equation(n)^2;
      case "^3":
        return (n) => equation(n)^3;
      case "^-1":
        return (n) => equation(n)^(-1);
      case "sin":
        return (n) => Math.Sin(equation(n));
      case "cos":
        return (n) => Math.Cos(equation(n));
      case "tan":
        return (n) => Math.Tan(equation(n));
      case "sin^-1":
        return (n) => Math.Asin(equation(n));
      case "cos^-1":
        return (n) => Math.Acos(equation(n));
      case "tan^-1":
        return (n) => Math.Atan(equation(n));
      case "sec":
        return (n) => (Math.Cos(equation(n))).ToNumber()^(-1);
      case "csc":
        return (n) => (Math.Sin(equation(n))).ToNumber()^(-1);
      case "cot":
        return (n) => (Math.Tan(equation(n))).ToNumber()^(-1);
      case "sec^-1":
        return (n) => (Math.Acos(equation(n))).ToNumber()^(-1);
      case "csc^-1":
        return (n) => (Math.Asin(equation(n))).ToNumber()^(-1);
      case "cot^-1":
        return (n) => (Math.Atan(equation(n))).ToNumber()^(-1);
      default:
        throw new InvalidOperationException($"Solo Exception {soloMod} does not exist.");
    }
  }
  public static Equation Sum(this Equation[] equations)
  {
    return (n) => Number.Sum(equations.Pull(e => e(n)));
  }
  public static Number Sum(this Equation[] equations, Number index)
  {
    return equations.Sum()(index);
  }
  public static Equation Multiply(this Equation equation, Number scalar)
  {
    return (n) => scalar * equation(n);
  }
  public static Equation Difference(this Equation[] equations)
  {
    Equation[] rest = equations.ToList().Skip(0).ToArray();
    return (n) => equations[0](n) - rest.Sum()(n);
  }
  internal static string[] soloModifiers = new string[]{
    "e^","Ln","Log","-","abs","sqrt","^2","^3","^-1","sin","cos","tan","sec","csc","cot","sin^-1","cos^-1","tan^-1","sec^-1","csc^-1","cot^-1","^x","x^"
  };
  internal static string[] dualModifiers = new string[]{
    "^","nRoot","nLog","+","-","*","/","//","%"
  };
  public static bool IsEquationModifier(this string mod) => soloModifiers.Contains(mod) || dualModifiers.Contains(mod);
  public static bool IsSoloEquationModifier(this string mod) => soloModifiers.Contains(mod);
  public static bool IsDualEquationModifier(this string mod) => dualModifiers.Contains(mod);
}
public static class DefaultEquations
{
  public static readonly Equation Sine = (n) => Math.Sin(n);
  public static readonly Equation Cosine = (n) => Math.Cos(n);
  public static readonly Equation Tangent = (n) => Math.Tan(n);
}