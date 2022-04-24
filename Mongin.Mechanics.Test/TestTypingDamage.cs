using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Damage;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestTypingDamage
{
    [TestMethod]
    public void TestIceQuadrupleDamageDragonPlusFlying()
        => Assert.AreEqual(4.0, TypingDamage.GetMultiplier(Typing.Ice, Typing.Dragon, Typing.Flying), 0.001);

    [TestMethod]
    public void TestWaterNormalDamageGrassPlusGround()
        => Assert.AreEqual(1.0, TypingDamage.GetMultiplier(Typing.Water, Typing.Grass, Typing.Ground), 0.001);

    [TestMethod]
    public void TestWaterNormalDamageGroundPlusGrass()
        => Assert.AreEqual(1.0, TypingDamage.GetMultiplier(Typing.Water, Typing.Ground, Typing.Grass), 0.001);

    [TestMethod]
    public void TestFireDoubleDamagePoisonIce()
        => Assert.AreEqual(2.0, TypingDamage.GetMultiplier(Typing.Fire, Typing.Poison, Typing.Ice), 0.001);
}