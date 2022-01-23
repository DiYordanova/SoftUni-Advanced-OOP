using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private string name = "Petar";
    private int experience = 0;
    private Hero hero;
    private Axe weapon;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero(name);
    }

    [Test]
    public void ShouldBeSetCurrect_WhenNameProvided()
    {
        Assert.AreEqual(hero.Name, name);
    }

    [Test]
    public void ShouldBeSetCurrect_WhenExperienceProvided()
    {       
        Assert.AreEqual(hero.Experience, experience);
    }   
}