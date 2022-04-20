namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
public sealed class LogisticModel : EquationModel
{
  public Number CarryingCapacity { get; init;}
  public Number InitialAmount { get; init;}
  public Number Rate { get; init;}
  public LogisticModel(Number capacity, Number initialAmount, Number rate) : base()
  {
    CarryingCapacity = capacity;
    InitialAmount = CarryingCapacity / initialAmount - 1.0;
    Rate = rate;
  }
  public override Number Evaluate(Number input) => CarryingCapacity / (1 + InitialAmount * Math.Pow(Math.E,Rate * -input));
  public override string GetModelType() => "LOGISTIC";
}