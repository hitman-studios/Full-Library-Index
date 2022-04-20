namespace Libraries.Display;
using Libraries;
using System.Runtime.InteropServices;
[AttributeUsage(System.AttributeTargets.Struct | System.AttributeTargets.Class | System.AttributeTargets.Interface, Inherited = true)]
public sealed class ComponentTypeAttribute : Attribute
{
  public ComponentTypes componentType { get; }
  public ComponentTypeAttribute([Optional]ComponentTypes type) : base()
  {
    componentType = type;
  }
}
[AttributeUsage(System.AttributeTargets.Struct | System.AttributeTargets.Class | System.AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
public sealed class ComponentPriorityAttribute : Attribute
{
  public ComponentPriority priority { get; }
  public ComponentPriorityAttribute([Optional]ComponentPriority p) : base()
  {
    priority = p;
  }
}
[AttributeUsage(System.AttributeTargets.Field | AttributeTargets.Property | System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = true)]
public sealed class DisplayLayerAttribute : Attribute
{
  public uint ConsoleLayer { get; private set; }
  public DisplayLayerAttribute(uint layer)
  {
    ConsoleLayer = layer;
  }
  public void SetLayer(uint newLayer)
  {
    ConsoleLayer = newLayer;
  }
}
[Flags]
public enum ComponentTypes
{
  General = 0,
  Display = 1,
  Input = 2,
  Output = 4,
  Processing = 8,
  Events = 16
}
public enum ComponentPriority
{
  None = -3,
  Minimal = -2,
  Low = -1,
  Average = 0,
  High = 1,
  Maximum = 2,
  Absolute = 3
}
