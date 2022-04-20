using System;
using Libraries;
namespace Libraries.Physics
{
    public struct PhysicalItem : IPhysical
    {
      public Number Mass { get; set; }
      public Coordinate Position { get; set; }
      public PhysicalItem(Number mass, Coordinate position)
      {
        Mass = mass;
        Position = position;
      }
    }
}