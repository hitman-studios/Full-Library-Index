// See https://aka.ms/new-console-template for more information
using Libraries.Modeling;
using Libraries.Physics;
using Libraries;
Equation e1 = (n) => 5.0 * n;
Equation main1 = e1.Modify("^",2.0);
Equation poly1 = new Polynomial((3,4),(2,3),(1,1),(5,3));
Console.WriteLine("Enumerating over main1.");
void Log(Number n) => Console.WriteLine(n.ToString());
main1.Enumerate(-10.0,10.0,0.5).ForEach(Log);