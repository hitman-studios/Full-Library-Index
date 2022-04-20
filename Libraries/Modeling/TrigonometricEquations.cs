namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
public sealed class SineModel : EquationModel
{
  public override Number Evaluate(Number input) => Math.Sin(horizontalFactor * input);
  public override string GetModelType() => "SINE";
  public Number horizontalFactor { get; }
  public SineModel([Optional]Number amplitude, [Optional]Number horiz, [Optional]Coordinate offset) : base(amplitude == 0.0 ? 1.0 : amplitude, offset)
  {
    horizontalFactor = horiz;
  }
}