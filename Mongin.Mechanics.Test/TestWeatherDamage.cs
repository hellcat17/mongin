using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Damage;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestWeatherDamage
{
    [TestMethod]
    public void TestFireDoubleDamageSun()
        => Assert.AreEqual(2.0, WeatherDamage.GetDamageMultiplier(Weather.Sunshine, Typing.Fire), 0.01);

    [TestMethod]
    public void TestFireHalfDamageRain()
        => Assert.AreEqual(0.5, WeatherDamage.GetDamageMultiplier(Weather.Rain, Typing.Fire), 0.01);

    [TestMethod]
    public void TestWaterHalfDamageSun()
        => Assert.AreEqual(0.5, WeatherDamage.GetDamageMultiplier(Weather.Sunshine, Typing.Water), 0.01);

    [TestMethod]
    public void TestWaterNormalDamageSandstorm()
        => Assert.AreEqual(1.0, WeatherDamage.GetDamageMultiplier(Weather.Sandstorm, Typing.Water), 0.01);

    [TestMethod]
    public void TestFireNormalDamageSandstorm()
        => Assert.AreEqual(1.0, WeatherDamage.GetDamageMultiplier(Weather.Sandstorm, Typing.Fire), 0.01);

    [TestMethod]
    public void TestNormalReceiveDamageHail()
        => Assert.AreEqual(1.0, WeatherDamage.GetDamagePerTurn(Weather.Hail, Typing.Normal, new(), 16), 0.01);

    [TestMethod]
    public void TestNormalReceiveDamageSandstorm()
        => Assert.AreEqual(1.0, WeatherDamage.GetDamagePerTurn(Weather.Sandstorm, Typing.Normal, new(), 16), 0.01);

    [TestMethod]
    public void TestRockNoDamageSandstorm()
        => Assert.AreEqual(0.0, WeatherDamage.GetDamagePerTurn(Weather.Sandstorm, Typing.Rock, new(), 16), 0.01);

    [TestMethod]
    public void TestGroundNoDamageSandstorm()
        => Assert.AreEqual(0.0, WeatherDamage.GetDamagePerTurn(Weather.Sandstorm, Typing.Grass, Typing.Ground, 16), 0.01);

    [TestMethod]
    public void TestSteelNoDamageSandstorm()
        => Assert.AreEqual(0.0, WeatherDamage.GetDamagePerTurn(Weather.Sandstorm, Typing.Steel, new(), 16), 0.01);

    [TestMethod]
    public void TestIceNoDamageHail()
        => Assert.AreEqual(0.0, WeatherDamage.GetDamagePerTurn(Weather.Hail, Typing.Water, Typing.Ice, 16), 0.01);
}