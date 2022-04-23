using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mongin.Mechanics.Experience;

namespace Mongin.Mechanics.Test;

[TestClass]
public class TestExperienceGain
{
    [TestMethod]
    public void TestStaticParamsContract()
    {
        Assert.ThrowsException<System.ArgumentException>(() => new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 0, ExpShareHolders: 0));
        Assert.ThrowsException<System.ArgumentException>(() => new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: -1, ExpShareHolders: 0));
        Assert.ThrowsException<System.ArgumentException>(() => new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 7, ExpShareHolders: 0));
        Assert.ThrowsException<System.ArgumentException>(() => new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 0, ExpShareHolders: -1));
        Assert.ThrowsException<System.ArgumentException>(() => new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 0, ExpShareHolders: 7));

        Assert.AreEqual(1, new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 0).UnfaintedContributors);
        Assert.AreEqual(6, new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 6, ExpShareHolders: 0).UnfaintedContributors);
        Assert.AreEqual(0, new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 0).ExpShareHolders);
        Assert.AreEqual(6, new ExpStaticParams(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 6).ExpShareHolders);
    }

    [TestMethod]
    public void TestGenVBasic()
    {
        ExpContributor contributor = new(Level: new(45), HoldsExpShare: false, HoldsLuckyEgg: false);
        ExpOpponent opponent = new(Level: new(50), ExpYield: 173);
        ExpStaticParams static_ = new(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 0);
        Assert.AreEqual(2916, new GenVExperienceGain().GetGainedExperience(contributor, opponent, static_));
    }

    [TestMethod]
    public void TestGenVMoreExpWithLuckyEgg()
    {
        ExpContributor contributor1 = new(Level: new(45), HoldsExpShare: false, HoldsLuckyEgg: false);
        ExpContributor contributor2 = new(Level: new(45), HoldsExpShare: false, HoldsLuckyEgg: true);
        ExpOpponent opponent = new(Level: new(50), ExpYield: 173);
        ExpStaticParams static_ = new(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 0);
        Assert.AreEqual(
            new GenVExperienceGain().GetGainedExperience(contributor1, opponent, static_) * 1.5,
            new GenVExperienceGain().GetGainedExperience(contributor2, opponent, static_),
            0.1);
    }

    [TestMethod]
    public void TestGenVMoreExpWithTrainerBattle()
    {
        ExpContributor contributor = new(Level: new(45), HoldsExpShare: false, HoldsLuckyEgg: false);
        ExpOpponent opponent = new(Level: new(50), ExpYield: 173);
        ExpStaticParams static1 = new(IsTrainerBattle: false, UnfaintedContributors: 1, ExpShareHolders: 0);
        ExpStaticParams static2 = new(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 0);
        Assert.IsTrue(
            new GenVExperienceGain().GetGainedExperience(contributor, opponent, static2)
            > new GenVExperienceGain().GetGainedExperience(contributor, opponent, static1));
    }

    [TestMethod]
    public void TestGenVLessExpWithMoreUnfaintedContributors()
    {

        ExpContributor contributor = new(Level: new(45), HoldsExpShare: false, HoldsLuckyEgg: false);
        ExpOpponent opponent = new(Level: new(50), ExpYield: 173);
        ExpStaticParams static1 = new(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 0);
        ExpStaticParams static2 = new(IsTrainerBattle: true, UnfaintedContributors: 4, ExpShareHolders: 0);
        Assert.AreEqual(
            new GenVExperienceGain().GetGainedExperience(contributor, opponent, static1) / 4.0,
            new GenVExperienceGain().GetGainedExperience(contributor, opponent, static2),
            0.1);
    }

    [TestMethod]
    public void TestGenVMoreExpWithLowerLevel()
    {
        ExpContributor contributor1 = new(Level: new(50), HoldsExpShare: false, HoldsLuckyEgg: false);
        ExpContributor contributor2 = new(Level: new(55), HoldsExpShare: false, HoldsLuckyEgg: false);
        ExpOpponent opponent = new(Level: new(50), ExpYield: 173);
        ExpStaticParams static_ = new(IsTrainerBattle: true, UnfaintedContributors: 1, ExpShareHolders: 0);
        Assert.IsTrue(
            new GenVExperienceGain().GetGainedExperience(contributor1, opponent, static_)
            > new GenVExperienceGain().GetGainedExperience(contributor2, opponent, static_));
    }

    [TestMethod]
    public void TestGenVMoreExpThanOthersWithExpShare()
    {
        ExpContributor contributor1 = new(Level: new(50), HoldsExpShare: true, HoldsLuckyEgg: false);
        ExpContributor contributor2 = new(Level: new(50), HoldsExpShare: false, HoldsLuckyEgg: false);
        ExpOpponent opponent = new(Level: new(50), ExpYield: 173);
        ExpStaticParams static_ = new(IsTrainerBattle: true, UnfaintedContributors: 2, ExpShareHolders: 1);
        Assert.IsTrue(
            new GenVExperienceGain().GetGainedExperience(contributor1, opponent, static_)
            > new GenVExperienceGain().GetGainedExperience(contributor2, opponent, static_));
    }
}