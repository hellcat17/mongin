using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestTypeTable
{
    [TestMethod]
    public void TestNormalNoEffectGhost()
        => Assert.AreEqual(TypeEffectiveness.NoEffect, TypeTable.Value[Typing.Normal][Typing.Ghost]);

    [TestMethod]
    public void TestFightingSuperEffectiveIce()
        => Assert.AreEqual(TypeEffectiveness.SuperEffective, TypeTable.Value[Typing.Fighting][Typing.Ice]);

    [TestMethod]
    public void TestWaterNormalPsychic()
        => Assert.AreEqual(TypeEffectiveness.Normal, TypeTable.Value[Typing.Water][Typing.Psychic]);

    [TestMethod]
    public void TestFightingNoEffectGhost()
        => Assert.AreEqual(TypeEffectiveness.NoEffect, TypeTable.Value[Typing.Fighting][Typing.Ghost]);

    [TestMethod]
    public void TestGhostNoEffectNormal()
        => Assert.AreEqual(TypeEffectiveness.NoEffect, TypeTable.Value[Typing.Ghost][Typing.Normal]);

    [TestMethod]
    public void TestPoisonNotVeryEffectivePoison()
        => Assert.AreEqual(TypeEffectiveness.NotVeryEffective, TypeTable.Value[Typing.Poison][Typing.Poison]);
}