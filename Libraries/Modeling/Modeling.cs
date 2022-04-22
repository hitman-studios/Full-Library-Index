namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
public static class mExtensions
{
  public static Equation Modify(this Equation equation, string multiMod, Number scalar)
  {
    switch(multiMod)
    {
      case "^":
        return (n) => equation(n)^scalar;
      case "nRoot":
        return (n) => Math.Pow(equation(n),1.0/scalar);
      case "nLog":
        return (n) => Math.Log(equation(n),scalar);
      case "+":
        return (n) => equation(n) + scalar;
      case "-":
        return (n) => equation(n) - scalar;
      case "*":
        return (n) => equation(n) * scalar;
      case "/":
        if(scalar == 0.0) throw new InvalidOperationException("DONT USE ZERO AS SCALAR");
        else return (n) => equation(n) / scalar;
      case "//":
        return (n) => Math.Floor((double)(equation(n) / scalar));
      case "%":
        return (n) => equation(n) % scalar;
      default:
        throw new InvalidOperationException("Modifier doesn\'t exist.");
    }
  }  
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
  private static string[] soloModifiers = new string[]{
    "e^","Ln","Log","-","abs","sqrt","^2","^3","^-1","sin","cos","tan","sec","csc","cot","sin^-1","cos^-1","tan^-1","sec^-1","csc^-1","cot^-1","f^x","x^f"
  };
  private static string[] dualModifiers = new string[]{
    "^","nRoot","nLog","+","-","*","/","//","%"
  };
}
