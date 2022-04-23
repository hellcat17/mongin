using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestEffectiveStats
{
    [TestMethod]
    public void TestSpeciesAbra()
    {
        BaseStats base_ = new()
        {
            HP = 25,
            Attack = 20,
            Defense = 15,
            SpecialAttack = 105,
            SpecialDefense = 55,
            Speed = 90
        };
        IndividualValues iv = new(
            HP: 10,
            Attack: 15,
            Defense: 23,
            SpecialAttack: 29,
            SpecialDefense: 5,
            Speed: 1);
        EffortValues ev = new(
            HP: 23,
            Attack: 6,
            Defense: 4,
            SpecialAttack: 200,
            SpecialDefense: 0,
            Speed: 150);
        EffectiveStats effective = new(
            Base: base_,
            IV: iv,
            EV: ev,
            Level: new Level(43),
            Nature: Nature.Modest);

        Assert.AreEqual(80, effective.HP);
        Assert.AreEqual(26, effective.Attack);
        Assert.AreEqual(28, effective.Defense);
        Assert.AreEqual(141, effective.SpecialAttack);
        Assert.AreEqual(54, effective.SpecialDefense);
        Assert.AreEqual(98, effective.Speed);
    }

    [TestMethod]
    public void TestStatHigherIfBoostedByNature()
    {
        Assert.IsTrue(
            CalculateWithNature(Nature.Bashful).SpecialAttack
            < CalculateWithNature(Nature.Mild).SpecialAttack);
    }

    [TestMethod]
    public void TestStatLowerIfWeakenedByNature()
    {
        Assert.IsTrue(
            CalculateWithNature(Nature.Bashful).SpecialAttack
            > CalculateWithNature(Nature.Adamant).SpecialAttack);
    }

    [TestMethod]
    public void TestStatHigherIfHigherLevel()
    {
        Assert.IsTrue(
            CalculateWithLevel(new(51)).Speed
            > CalculateWithLevel(new(50)).Speed);
    }

    [TestMethod]
    public void TestStatHigherIfHigherBaseStat()
    {
        Assert.IsTrue(
            CalculateWithAttackBaseStat(110).Attack
            > CalculateWithAttackBaseStat(100).Attack);
    }

    [TestMethod]
    public void TestStatHigherIfHigherIVStat()
    {
        Assert.IsTrue(
            CalculateWithAttackIVStat(31).Attack
            > CalculateWithAttackIVStat(23).Attack);
    }

    [TestMethod]
    public void TestStatHigherIfHigherEVStat()
    {
        Assert.IsTrue(
            CalculateWithAttackEVStat(224).Attack
            > CalculateWithAttackEVStat(200).Attack);
    }

    private readonly static Level TestLevel = new(30);
    private readonly static IndividualValues TestIV = new(0, 0, 0, 0, 0, 0);
    private readonly static EffortValues TestEV = new(0, 0, 0, 0, 0, 0);
    private readonly static Nature TestNature = Nature.Adamant;
    private readonly static BaseStats TestBase = new()
    {
        HP = 25,
        Attack = 20,
        Defense = 15,
        SpecialAttack = 105,
        SpecialDefense = 55,
        Speed = 90
    };

    private static EffectiveStats CalculateWithNature(Nature nature) => new(TestBase, TestIV, TestEV, TestLevel, nature);

    private static EffectiveStats CalculateWithLevel(Level level) => new(TestBase, TestIV, TestEV, level, TestNature);

    private static EffectiveStats CalculateWithAttackBaseStat(int stat)
    {
        var mod = TestBase with { Attack = stat };
        return new(mod, TestIV, TestEV, TestLevel, TestNature);
    }

    private static EffectiveStats CalculateWithAttackIVStat(int stat)
    {
        var mod = new IndividualValues(TestIV.HP, stat, TestIV.Defense, TestIV.SpecialAttack, TestIV.SpecialDefense, TestIV.Speed);
        return new(TestBase, mod, TestEV, TestLevel, TestNature);
    }

    private static EffectiveStats CalculateWithAttackEVStat(int stat)
    {
        var mod = new EffortValues(TestEV.HP, stat, TestEV.Defense, TestEV.SpecialAttack, TestEV.SpecialDefense, TestEV.Speed);
        return new(TestBase, TestIV, mod, TestLevel, TestNature);
    }
}