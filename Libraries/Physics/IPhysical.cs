using System;
namespace Libraries.Physics;
using Libraries;
public interface IPhysical : IPositioned
{
  public Number Mass { get; set; }
}