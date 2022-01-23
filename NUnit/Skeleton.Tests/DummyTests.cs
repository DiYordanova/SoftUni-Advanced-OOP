using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 5;
    private int experience = 10;
    private Dummy dummy;
    private Dummy deadDummy;

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(health, experience);
        this.deadDummy = new Dummy(-5, experience);
    }

    [Test]
    public void ShouldBeSetCurrect_WhenDummyHealthProvided()
    {
        Assert.AreEqual(dummy.Health, health);
    }

    [Test]
    public void ShouldThrowException_WhenAttackDummyIsDead()
    {
        Assert.That(() =>
        {
            deadDummy.TakeAttack(3);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }


    [Test]
    public void ShouldDecreaseHealth_WhenAttact()
    {
        int attactPoints = 3;
        dummy.TakeAttack(attactPoints);
        Assert.AreEqual(dummy.Health, health - attactPoints);
    }

    [Test]
    public void ShouldBeDead_WhenHealthIsZero()
    {
        Dummy dummy = new Dummy(0, experience);
        Assert.AreEqual(dummy.IsDead(), true);
    }

    [Test]
    public void ShuldBeAlive_WhenHealthIsPositive()
    {
        Assert.AreEqual(dummy.IsDead(), false);
    }

    [Test]
    public void ShouldBeDead_WhenHealthIsNegative()
    {
        Assert.AreEqual(deadDummy.IsDead(), true);
    }

    [Test]
    public void ShouldGiveExperiance_WhenDead()
    {
        Assert.AreEqual(deadDummy.GiveExperience(), experience);
    }

    [Test]
    public void ShouldThrowException_WhenAliveGiveExperience()
    {
        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
