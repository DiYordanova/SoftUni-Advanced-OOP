using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private string name = "Warrior";
        private int damage = 50;
        private int hp = 20;
        private Warrior warrior; 

        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        [TestCase(" ", 10, 100)]
        [TestCase("", 10, 100)]
        [TestCase(null, 10, 100)]
        [TestCase("Wrrior", 0, 100)]
        [TestCase("Warrior", -5, 100)]        
        [TestCase("Warrior", 10, -5)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            this.warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(this.warrior.Name, name);
            Assert.AreEqual(this.warrior.Damage, damage);
            Assert.AreEqual(this.warrior.HP, hp);
        }

        [Test]
        [TestCase(30, 55)]
        [TestCase(15, 55)]
        [TestCase(55, 30)]
        [TestCase(55, 15)]

        public void Attack_ThrowsException_WhenHpIsLessThanMinimum(int attackerHp, int warrierHp)
        {
            Warrior attacker = new Warrior("Attacker", 50, attackerHp);
            Warrior warrior = new Warrior("Warrior", 10, warrierHp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [Test]
        public void Attack_ThrowsException_WhenAttackerHpIsLessThanEnemydamage()
        {
            Warrior attacker = new Warrior("Attacker", 50, 100);
            Warrior warrior = new Warrior("Warrier", attacker.HP + 1, 100);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior)); 
        }

        public void Attack_DecreasesAttackerHealthPoints()
        {
            int initialAttackerHealthPoints = 100;
            Warrior attacker = new Warrior("Attacker", 50, initialAttackerHealthPoints);
            Warrior warrior = new Warrior("Warrier", 30, 100);
            Assert.AreEqual(attacker.HP, initialAttackerHealthPoints - warrior.Damage);
        }

        [Test]
        public void Attack_SetEnemyHealthPointsToZero_WhenAttackerDamageIsGreaterThanEnemyHp()
        {
            Warrior attacker = new Warrior("Attacker", 100, 70);
            Warrior warrior = new Warrior("Warrier", 70, 50);
            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_DecreaseEnemyHpByAttackerDamage()
        {
            Warrior attacker = new Warrior("Attacker", 50, 70);
            Warrior warrior = new Warrior("Warrier", 70, 100);
            attacker.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(50));
        }
    }
}