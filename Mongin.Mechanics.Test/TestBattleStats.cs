using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestBattleStats
{
    [TestMethod]
    public void TestDoubleStatIfBoostedTwoTimes()
    {
        Assert.AreEqual(TestStats.Attack * 2, new BattleStats(TestStats, BoostAttack(2)).Attack);
    }

    [TestMethod]
    public void TestTripleStatIfBoostedFourTimes()
    {
        Assert.AreEqual(TestStats.Attack * 3, new BattleStats(TestStats, BoostAttack(4)).Attack);
    }

    [TestMethod]
    public void TestQuadrupleStatIfBoostedSixTimes()
    {
        Assert.AreEqual(TestStats.Attack * 4, new BattleStats(TestStats, BoostAttack(6)).Attack);
    }

    [TestMethod]
    public void TestHalveStatIfWeakenedTwoTimes()
    {
        Assert.AreEqual(TestStats.Attack / 2, new BattleStats(TestStats, BoostAttack(-2)).Attack);
    }

    [TestMethod]
    public void TestThirdStatIfWeakenedFourTimes()
    {
        Assert.AreEqual(TestStats.Attack / 3, new BattleStats(TestStats, BoostAttack(-4)).Attack);
    }

    [TestMethod]
    public void TestQuarterStatIfWeakenedSixTimes()
    {
        Assert.AreEqual(TestStats.Attack / 4, new BattleStats(TestStats, BoostAttack(-6)).Attack);
    }

    private readonly static EffectiveStats TestStats = new(
        Base: new() { Attack = 100 },
        IV: new(0, 0, 0, 0, 0, 0),
        EV: new(0, 0, 0, 0, 0, 0),
        Level: new(50),
        Nature: Nature.Quirky);

    private static TemporaryBoosts BoostAttack(int boost) => new(Attack: boost, Defense: 0, SpecialAttack: 0, SpecialDefense: 0, Speed: 0);
}