using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestEffortValues
{
    [TestMethod]
    public void TestIndividualLowerBound()
    {
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: -1, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: -1, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: -1, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: -1, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: -1, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: -1));
    }

    [TestMethod]
    public void TestIndividualUpperBound()
    {
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 256, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 256, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: 256, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 256, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 256, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 256));
    }

    [TestMethod]
    public void TestAccumulatedUpperBound()
    {
        Assert.ThrowsException<System.ArgumentException>(()
            => new EffortValues(HP: 255, Attack: 255, Defense: 1, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
    }

    [TestMethod]
    public void TestWithinAllBounds()
    {
        Assert.AreEqual(0, new EffortValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0).Speed);
        Assert.AreEqual(252, new EffortValues(HP: 252, Attack: 0, Defense: 4, SpecialAttack: 0, SpecialDefense: 252, Speed: 0).HP);
    }
}