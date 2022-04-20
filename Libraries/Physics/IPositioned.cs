using System;
using Libraries;
namespace Libraries.Physics
{
    public interface IPositioned
    {
      public Coordinate Position { get; set; }
    }
}