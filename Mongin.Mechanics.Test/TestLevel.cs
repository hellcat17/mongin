using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestLevel
{
    [TestMethod]
    public void TestMinimumLevelEnforced()
    {
        Assert.ThrowsException<System.ArgumentException>(() => new Level(0));
        Assert.ThrowsException<System.ArgumentException>(() => new Level(-1));
        Assert.ThrowsException<System.ArgumentException>(() => new Level(-1000));
    }

    [TestMethod]
    public void TestMaximumLevelEnforced()
    {
        Assert.ThrowsException<System.ArgumentException>(() => new Level(101));
        Assert.ThrowsException<System.ArgumentException>(() => new Level(1000));
    }

    [TestMethod]
    public void TestValidLevels()
    {
        Assert.IsTrue(new Level(1).Value == 1, "Level does not match");
        Assert.IsTrue(new Level(10).Value == 10, "Level does not match");
        Assert.IsTrue(new Level(50).Value == 50, "Level does not match");
        Assert.IsTrue(new Level(100).Value == 100, "Level does not match");
    }
}