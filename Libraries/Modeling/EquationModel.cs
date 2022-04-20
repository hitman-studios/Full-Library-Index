namespace Libraries.Modeling;
using Libraries;
using System.Runtime.InteropServices;
/**
<summary>
The model for complicated equations.
</summary>
<remarks>
Abstract methods to declare:<br/>
<strong>double</strong> <see cref="EquationModel.Evaluate(double)"/> <br/>
<strong>string</strong> <see cref="EquationModel.GetModelType"/> <br/>
Methods: <br/>
double <c>this[double index]</c> - evaluates the equation at the given x-value <br/>
ToFunc()




</remarks>
*/
[Syntax("Libraries.Physics.EquationModel","The abstract model for making math equations. Does not use + or - or any other operations.", "Dan Budd","To Derive: You must override these abstract methods:","public abstract Libraries.Number Evaluate(Libraries.Number) <- the equation","public abstract string GetModelType() <- Gets the model type in a string.")]
public abstract class EquationModel
{
  public Number this[Number index] => masterScale * Evaluate(index + masterOffset.x) + masterOffset.y;
  public abstract Number Evaluate(Number input);
  public Coordinate masterOffset { get; }
  public Number masterScale { get; }
  protected EquationModel([Optional]Number masterScale, [Optional]Coordinate masterOffset)
  {
    this.masterOffset = masterOffset;
    this.masterScale = masterScale == 0.0 ? 1.0 : masterScale;
  }
  public abstract string GetModelType();
  public Func<Number,Number> ToFunc() => (input) => this[input];
}