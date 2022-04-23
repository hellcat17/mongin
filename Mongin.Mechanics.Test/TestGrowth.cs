using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Experience;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestGrowth
{
    [TestMethod]
    public void TestGenVErraticGrowth()
    {
        IGrowth growth = new GenVGrowth();
        Assert.AreEqual(15, growth.GetTotalExperience(GrowthRate.Erratic, new(2)));
        Assert.AreEqual(23437, growth.GetTotalExperience(GrowthRate.Erratic, new(25)));
        Assert.AreEqual(125000, growth.GetTotalExperience(GrowthRate.Erratic, new(50)));
        Assert.AreEqual(326531, growth.GetTotalExperience(GrowthRate.Erratic, new(75)));
        Assert.AreEqual(600000, growth.GetTotalExperience(GrowthRate.Erratic, new(100)));
    }

    [TestMethod]
    public void TestGenVFastGrowth()
    {
        IGrowth growth = new GenVGrowth();
        Assert.AreEqual(6, growth.GetTotalExperience(GrowthRate.Fast, new(2)));
        Assert.AreEqual(12500, growth.GetTotalExperience(GrowthRate.Fast, new(25)));
        Assert.AreEqual(100000, growth.GetTotalExperience(GrowthRate.Fast, new(50)));
        Assert.AreEqual(337500, growth.GetTotalExperience(GrowthRate.Fast, new(75)));
        Assert.AreEqual(800000, growth.GetTotalExperience(GrowthRate.Fast, new(100)));
    }

    [TestMethod]
    public void TestGenVMediumFastGrowth()
    {
        IGrowth growth = new GenVGrowth();
        Assert.AreEqual(8, growth.GetTotalExperience(GrowthRate.MediumFast, new(2)));
        Assert.AreEqual(15625, growth.GetTotalExperience(GrowthRate.MediumFast, new(25)));
        Assert.AreEqual(125000, growth.GetTotalExperience(GrowthRate.MediumFast, new(50)));
        Assert.AreEqual(421875, growth.GetTotalExperience(GrowthRate.MediumFast, new(75)));
        Assert.AreEqual(1000000, growth.GetTotalExperience(GrowthRate.MediumFast, new(100)));
    }

    [TestMethod]
    public void TestGenVMediumSlowGrowth()
    {
        IGrowth growth = new GenVGrowth();
        Assert.AreEqual(9, growth.GetTotalExperience(GrowthRate.MediumSlow, new(2)));
        Assert.AreEqual(11735, growth.GetTotalExperience(GrowthRate.MediumSlow, new(25)));
        Assert.AreEqual(117360, growth.GetTotalExperience(GrowthRate.MediumSlow, new(50)));
        Assert.AreEqual(429235, growth.GetTotalExperience(GrowthRate.MediumSlow, new(75)));
        Assert.AreEqual(1059860, growth.GetTotalExperience(GrowthRate.MediumSlow, new(100)));
    }

    [TestMethod]
    public void TestGenVSlowGrowth()
    {
        IGrowth growth = new GenVGrowth();
        Assert.AreEqual(10, growth.GetTotalExperience(GrowthRate.Slow, new(2)));
        Assert.AreEqual(19531, growth.GetTotalExperience(GrowthRate.Slow, new(25)));
        Assert.AreEqual(156250, growth.GetTotalExperience(GrowthRate.Slow, new(50)));
        Assert.AreEqual(527343, growth.GetTotalExperience(GrowthRate.Slow, new(75)));
        Assert.AreEqual(1250000, growth.GetTotalExperience(GrowthRate.Slow, new(100)));
    }

    [TestMethod]
    public void TestGenVFluctuatingGrowth()
    {
        IGrowth growth = new GenVGrowth();
        Assert.AreEqual(4, growth.GetTotalExperience(GrowthRate.Fluctuating, new(2)));
        Assert.AreEqual(12187, growth.GetTotalExperience(GrowthRate.Fluctuating, new(25)));
        Assert.AreEqual(142500, growth.GetTotalExperience(GrowthRate.Fluctuating, new(50)));
        Assert.AreEqual(614566, growth.GetTotalExperience(GrowthRate.Fluctuating, new(76)));
        Assert.AreEqual(1640000, growth.GetTotalExperience(GrowthRate.Fluctuating, new(100)));
    }

    [TestMethod]
    public void TestGenVMaximumExperience()
    {
        Assert.AreEqual(1640000, new GenVGrowth().GetMaximumExperience(GrowthRate.Fluctuating));
    }

    [TestMethod]
    public void TestGenVZeroMissingIfMoreThanRequired()
    {
        Assert.AreEqual(0, new GenVGrowth().GetMissingExperience(GrowthRate.Fast, 1000, new(5)));
    }

    [TestMethod]
    public void TestGenVMissingExperience()
    {
        Assert.AreEqual(109, new GenVGrowth().GetMissingExperience(GrowthRate.Fast, 300, new(8)));
    }

    [TestMethod]
    public void TestGenVExperienceProgress()
    {
        Assert.AreEqual(0.25, new GenVGrowth().GetExperienceProgress(GrowthRate.Fluctuating, 601, new(10)), 0.05);
    }

    [TestMethod]
    public void TestGenVExperienceProgressAtMaximumLevel()
    {
        Assert.AreEqual(0.0, new GenVGrowth().GetExperienceProgress(GrowthRate.Fluctuating, 601, new(Level.Maximum)), 0.01);
    }
}