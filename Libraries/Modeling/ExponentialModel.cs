namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
public sealed class ExponentialModel : EquationModel
{
  public Number @base { get; init; }
  public Number powerCoefficient { get; init; }
  public ExponentialModel([Optional]Number base_, [Optional]Number coeff, [Optional]Number mScale, [Optional]Coordinate mOffset) : base(mScale, mOffset)
  {
    @base = base_ == 0.0 ? Math.E : base_;
    powerCoefficient = coeff == 0.0 ? 1.0 : coeff;
  }
  public override Number Evaluate(Number input) => Math.Pow(@base,powerCoefficient * input);
  public override string GetModelType() => "EXPONENTIAL";
}