using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestIndividualValues
{
    [TestMethod]
    public void TestLowerBound()
    {
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: -1, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: -1, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: -1, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: -1, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: -1, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: -1));
    }

    [TestMethod]
    public void TestUpperBound()
    {
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 32, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 32, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: 32, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 32, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 32, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new IndividualValues(HP: 0, Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 32));
    }

    [TestMethod]
    public void TestWithinBounds()
    {
        Assert.AreEqual(0, new IndividualValues(HP: 0, Attack: 1, Defense: 20, SpecialAttack: 21, SpecialDefense: 10, Speed: 3).HP);
        Assert.AreEqual(31, new IndividualValues(HP: 0, Attack: 1, Defense: 20, SpecialAttack: 21, SpecialDefense: 10, Speed: 31).Speed);
    }
}