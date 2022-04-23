using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestTemporaryBoosts
{
    [TestMethod]
    public void TestLowerBound()
    {
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: -7, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: -7, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: 0, SpecialAttack: -7, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: -7, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: -7));
    }

    [TestMethod]
    public void TestUpperBound()
    {
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 7, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: 7, SpecialAttack: 0, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: 0, SpecialAttack: 7, SpecialDefense: 0, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 7, Speed: 0));
        Assert.ThrowsException<System.ArgumentException>(()
            => new TemporaryBoosts(Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 7));
    }

    [TestMethod]
    public void TestWithinBounds()
    {
        Assert.AreEqual(-6, new TemporaryBoosts(Attack: -6, Defense: -1, SpecialAttack: -2, SpecialDefense: -3, Speed: -4).Attack);
        Assert.AreEqual(0, new TemporaryBoosts(Attack: 0, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0).SpecialAttack);
        Assert.AreEqual(6, new TemporaryBoosts(Attack: 1, Defense: 2, SpecialAttack: 3, SpecialDefense: 4, Speed: 6).Speed);
    }
}