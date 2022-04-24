using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Damage;
using Mongin.Mechanics.Stats;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestMoveDamage
{
    [TestMethod]
    public void TestDamageRangeContract()
    {
        Assert.ThrowsException<System.ArgumentException>(() => new DamageRange(-1));
        Assert.ThrowsException<System.ArgumentException>(() => new DamageRange(16));

        Assert.AreEqual(0, new DamageRange(0).Value);
        Assert.AreEqual(7, new DamageRange(7).Value);
        Assert.AreEqual(15, new DamageRange(15).Value);
    }

    [TestMethod]
    public void TestFinalDamageZeroIfNoEffect()
    {
        Assert.AreEqual(0, MoveDamage.GetFinalDamage(100, new(0), new(), TypeEffectiveness.NoEffect, new(), 1.0));
    }

    [TestMethod]
    public void TestFinalDamageBasic()
    {
        MoveDamageConditions conditions = new()
        {
            SameTypeAttackBonus = true,
            IsBurned = false,
            IsPhysicalMove = false
        };

        for (int i = DamageRange.Minimum; i <= DamageRange.Maximum; i++)
        {
            var damage = MoveDamage.GetFinalDamage(
                TestSpecialBaseDamage, new(i), conditions, TypeEffectiveness.Normal, new(), 1.0);
            Assert.AreEqual(TestExpectedSpecialDamage[i], damage, $"Failed for range {i}");
        }
    }

    [TestMethod]
    public void TestFinalDamageBurnNoEffectIfSpecial()
    {
        MoveDamageConditions conditions = new()
        {
            SameTypeAttackBonus = true,
            IsBurned = true,
            IsPhysicalMove = false
        };

        for (int i = DamageRange.Minimum; i <= DamageRange.Maximum; i++)
        {
            var damage = MoveDamage.GetFinalDamage(
                TestSpecialBaseDamage, new(i), conditions, TypeEffectiveness.Normal, new(), 1.0);
            Assert.AreEqual(TestExpectedSpecialDamage[i], damage);
        }
    }

    [TestMethod]
    public void TestFinalDamageHalfIfBurned()
    {
        MoveDamageConditions conditions = new()
        {
            SameTypeAttackBonus = false,
            IsBurned = true,
            IsPhysicalMove = true
        };

        for (int i = DamageRange.Minimum; i <= DamageRange.Maximum; i++)
        {
            var damage = MoveDamage.GetFinalDamage(
                TestPhysicalBaseDamage, new(i), conditions, TypeEffectiveness.Normal, new(), 1.0);
            Assert.AreEqual(TestExpectedPhysicalDamage[i] / 2, damage);
        }
    }

    [TestMethod]
    public void TestFinalDamageDoubleIfSuperEffective()
    {
        MoveDamageConditions conditions = new()
        {
            SameTypeAttackBonus = true,
            IsBurned = false,
            IsPhysicalMove = false
        };

        for (int i = DamageRange.Minimum; i <= DamageRange.Maximum; i++)
        {
            var damage = MoveDamage.GetFinalDamage(
                TestSpecialBaseDamage, new(i), conditions, TypeEffectiveness.SuperEffective, new(), 1.0);
            Assert.AreEqual(TestExpectedSpecialDamage[i] * 2, damage);
        }
    }

    [TestMethod]
    public void TestFinalDamageHalfIfNotVeryEffective()
    {
        MoveDamageConditions conditions = new()
        {
            SameTypeAttackBonus = true,
            IsBurned = false,
            IsPhysicalMove = false
        };

        for (int i = DamageRange.Minimum; i <= DamageRange.Maximum; i++)
        {
            var damage = MoveDamage.GetFinalDamage(
                TestSpecialBaseDamage, new(i), conditions, TypeEffectiveness.NotVeryEffective, new(), 1.0);
            Assert.AreEqual(TestExpectedSpecialDamage[i] / 2, damage);
        }
    }

    private readonly static Level TestLevel = new(50);
    private readonly static BaseStats TestAttackerBaseStats = new()
    {
        HP = 25,
        Attack = 20,
        Defense = 15,
        SpecialAttack = 105,
        SpecialDefense = 55,
        Speed = 90
    };
    private readonly static BaseStats TestDefenderBaseStats = new()
    {
        HP = 95,
        Attack = 70,
        Defense = 73,
        SpecialAttack = 85,
        SpecialDefense = 90,
        Speed = 60
    };
    private readonly static EffectiveStats TestAttackerStats
        = new(TestAttackerBaseStats, new(0, 0, 0, 0, 0, 0), new(0, 0, 0, 0, 0, 0), TestLevel, Nature.Bashful);
    private readonly static EffectiveStats TestDefenderStats
        = new(TestDefenderBaseStats, new(0, 0, 0, 0, 0, 0), new(0, 0, 0, 0, 0, 0), TestLevel, Nature.Bashful);
    private readonly static int TestPhysicalBaseDamage
        = MoveDamage.GetBaseDamage(50, TestLevel, TestAttackerStats.Attack, TestDefenderStats.Defense);
    private readonly static int TestSpecialBaseDamage
        = MoveDamage.GetBaseDamage(90, TestLevel, TestAttackerStats.SpecialAttack, TestDefenderStats.SpecialDefense);
    private readonly static int[] TestExpectedPhysicalDamage
        = { 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9 };
    private readonly static int[] TestExpectedSpecialDamage
        = { 58, 60, 60, 61, 61, 63, 63, 64, 64, 66, 66, 67, 67, 69, 69, 70 };
}