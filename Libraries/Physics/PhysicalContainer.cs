namespace Libraries.Physics;
using Libraries;
using System;
using System.Collections;
using System.Collections.Generic;
public class PhysicalContainer : IEnumerable
{
  // TODO: Add extension method for adding IPhysical objects
  private List<IPhysical> objects = new List<IPhysical>();
  public IPhysical[] Items => objects.ToArray();
  public PhysicalContainer(params IPhysical[] physicals)
  {
    objects = physicals.ToList();
  }
  internal void Add(IPhysical p)  {if(!objects.Contains(p)) objects.Add(p);}
  internal bool Contains(IPhysical p) => objects.Contains(p);
  internal bool Remove(IPhysical p) => objects.Remove(p);
  public Coordinate CenterOfMass => objects.Count > 0 ? objects.ToArray().GetCenterOfMass() : Coordinate.Origin;
  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this.GetEnumerator();
  public IEnumerator<IPhysical> GetEnumerator()
  {
    foreach(IPhysical i in objects)
    {
      yield return i;
    }
  }
}