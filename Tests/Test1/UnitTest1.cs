using NUnit;
using NUnit.Framework;
using System;
using Libraries;
using Libraries.Modeling;
namespace Test1;
[TestFixture]
public class Tests
{
    private LogisticModel model0;
    private LinearModel model1;
    private Equation equation1;
    [SetUp]
    public void Setup()
    {
      model0 = new LogisticModel(100.0, 5.0, 0.02);
      model1 = new LinearModel(4.0,2);
      Equation eq = ((n) => 10.0* n + 5.0 * n^(4.0));
      equation1 = eq.Modify("-");
    }
    private void Log(Number n) => Console.WriteLine(n.ToString());

    [Test]
    public void Test1()
    {
        Assert.IsTrue(model1[5.0] == 22.0);
    }
    [TestCase(0.0,5.0)]
    public void Test2(double n1, double n2)
    {
      // Assert.Value
      Assert.IsTrue(model0[n1.ToNumber()] == n2.ToNumber(), $"f({n1.ToNumber().ToString()}) should equal {model0[n1.ToNumber()].ToString()}");
    }
}