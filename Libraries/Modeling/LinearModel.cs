namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
public sealed class LinearModel : EquationModel
{
  public LinearModel([Optional]Number slope,[Optional]Number offset) : base(slope, offset)
  {
    // 
  }
  public override Number Evaluate(Number input) => input;
  public override string GetModelType() => "LINEAR";
}