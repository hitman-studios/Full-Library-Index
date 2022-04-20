namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
public sealed class QuadraticModel : EquationModel
{
  public Number Ax2;
  public Number Bx;
  public Number C;
  public QuadraticModel(Number Ax2, Number Bx, Number C) : base()
  {
    this.Ax2 = Ax2;
    this.Bx = Bx;
    this.C = C;
  }
  // public QuadraticModel(Number )
  public override Number Evaluate(Number input) => Ax2 * Math.Pow(input,2.0) + Bx * input + C;
  public override string GetModelType() => "QUADRATIC";
}