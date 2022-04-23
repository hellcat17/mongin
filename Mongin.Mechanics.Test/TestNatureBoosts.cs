using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestNatureBoosts
{
    [TestMethod]
    public void TestContract()
    {
        Assert.ThrowsException<System.ArgumentException>(() => NatureBoosts.Get(Nature.Bold, StatName.HP));
    }

    [TestMethod]
    public void TestBoldNature()
    {
        Assert.AreEqual(NatureBoosts.Get(Nature.Bold, StatName.Defense), NatureStatChange.Boosted);
        Assert.AreEqual(NatureBoosts.Get(Nature.Bold, StatName.Attack), NatureStatChange.Weakened);
        Assert.AreEqual(NatureBoosts.Get(Nature.Bold, StatName.SpecialAttack), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Bold, StatName.SpecialDefense), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Bold, StatName.Speed), NatureStatChange.Unaffected);
    }

    [TestMethod]
    public void TestImpishNature()
    {
        Assert.AreEqual(NatureBoosts.Get(Nature.Impish, StatName.Defense), NatureStatChange.Boosted);
        Assert.AreEqual(NatureBoosts.Get(Nature.Impish, StatName.Attack), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Impish, StatName.SpecialAttack), NatureStatChange.Weakened);
        Assert.AreEqual(NatureBoosts.Get(Nature.Impish, StatName.SpecialDefense), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Impish, StatName.Speed), NatureStatChange.Unaffected);
    }

    [TestMethod]
    public void TestQuietNature()
    {
        Assert.AreEqual(NatureBoosts.Get(Nature.Quiet, StatName.Defense), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quiet, StatName.Attack), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quiet, StatName.SpecialAttack), NatureStatChange.Boosted);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quiet, StatName.SpecialDefense), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quiet, StatName.Speed), NatureStatChange.Weakened);
    }

    [TestMethod]
    public void TestQuirkyNature()
    {
        Assert.AreEqual(NatureBoosts.Get(Nature.Quirky, StatName.Defense), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quirky, StatName.Attack), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quirky, StatName.SpecialAttack), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quirky, StatName.SpecialDefense), NatureStatChange.Unaffected);
        Assert.AreEqual(NatureBoosts.Get(Nature.Quirky, StatName.Speed), NatureStatChange.Unaffected);
    }
}