// See https://aka.ms/new-console-template for more information
using Libraries.Modeling;
using Libraries.Physics;
using Libraries;
var model1 = new LinearModel(5.0,3.0);
Console.WriteLine("Hello, World!");
Console.WriteLine(model1[5.0]);
PhysicalContainer container = new PhysicalContainer();
container.AddItem(new PhysicalItem(5.0,(2.0,4.0)),true);
container.AddItem(new PhysicalItem(10.0,(1.0,10.0)),true);
// SyntaxInfo? info;
Extensions.PrintSyntax<EquationModel>();
4.DisplayTODOs();
DataInfoAttribute.DisplayAll();