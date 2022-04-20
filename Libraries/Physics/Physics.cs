namespace Libraries.Physics;
using Libraries;
using Libraries.Modeling;
public static class PhysicsMethods
{
  public static Coordinate GetCenterOfMass<T>(this T[] items) where T : IPhysical
  {
    Number totalMass = items.Pull((item) => item.Mass).Sum();
    Number momentX = items.Pull((item) => item.Position.x * item.Mass).Sum();
    Number momentY = items.Pull((item) => item.Position.y * item.Mass).Sum();
    return new Coordinate(momentX / totalMass, momentY / totalMass);
  }
  public static void AddItem<T>(this PhysicalContainer container, T t, bool show = false) where T : IPhysical
  {
    container.Add(t);
    if(show) Console.WriteLine($"Center of Mass Changed. New Center of Mass: {container.CenterOfMass}");
  }
  public static bool Contains<T>(this PhysicalContainer container, T t) where T : IPhysical
  {
    return container.Contains(t);
  }
  public static bool Remove<T>(this PhysicalContainer container, T t) where T : IPhysical
  {
    return container.Remove(t);
  }
  public static Number GetHeat(Number mass, Number specificHeat, Number temperatureChange)
  {
    return mass * specificHeat * temperatureChange;
  }
  // U = Q + W
  // Q = mC * dT
}