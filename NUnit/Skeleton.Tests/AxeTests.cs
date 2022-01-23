using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private int attact = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.axe = new Axe(attact, durability);
        this.dummy = new Dummy(5, 6);
    }


    [Test]
    public void ShouldBeSetCurrectly_WhenAxeAttactProvided()
    {
        Assert.AreEqual(axe.AttackPoints, attact);
    }

    [Test]
    public void ShouldBeSetCurrectly_WhenAxeDurabilityProvided()
    {
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }

    [Test]
    public void ShouldLooseDurabilityPoints_WhenAxeAttacks()
    {
        axe.Attack(dummy);
        Assert.AreEqual(durability - 1, axe.DurabilityPoints);
    }

    [Test]
    public void ThrowNewExeption_WhenAxeAttacksWithDurabilityPointsZero()
    {
       Dummy dummy = new Dummy(5000, 5000);
        Assert.That(() =>
         {
             for (int i = 0; i < 7; i++)
             {
                 axe.Attack(dummy);
             }
         }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));        
    }
}