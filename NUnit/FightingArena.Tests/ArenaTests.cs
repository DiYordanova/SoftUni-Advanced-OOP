using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Ctor_InitializerWarriors()
        {
            Assert.That(this.arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Count_IsZero_WhenArenaIsEmpty()
        {
            Assert.That(this.arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Enroll_ThrowException_WhenWarrierAlreadyExcists()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 50, 50));
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior("Warrior", 100, 100)));
        }

        [Test]
        public void Enroll_IncreasesArenaCount() 
        {
            this.arena.Enroll(new Warrior("Warrior", 100, 100));
            Assert.AreEqual(arena.Count, 1);
        }

        [Test]
        public void Enroll_AddsWarriorToWarriors()
        {
            string name = "Warrior";
            this.arena.Enroll(new Warrior(name, 100, 100));
            Assert.That(this.arena.Warriors.Any(w => w.Name == name), Is.True);
        }

        [Test]
        public void Fight_ThrowException_WhenDefenderDoesNotExists()
        {
            this.arena.Enroll(new Warrior("Name", 50, 50));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Name", "Defender"));
        }

        [Test]
        public void Fight_ThrowException_WhenAttackerDoesNotExists()
        {
            this.arena.Enroll(new Warrior("Name", 50, 50));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", "Name"));
        }


        [Test]
        public void Fight_ThrowException_WhenBothDoesNotExists()
        {          
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Attacker", "Defender"));
        }

        [Test]
        public void Fight_BothWarriorsLoseHpInFight()
        {
            int initialHp = 100;
            Warrior attacker = new Warrior("Attacker", 50, initialHp);
            Warrior defender = new Warrior("Warrior", 50, initialHp);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);
            this.arena.Fight(attacker.Name, defender.Name);

            Assert.That(attacker.HP, Is.EqualTo(initialHp - defender.Damage));
            Assert.That(defender.HP, Is.EqualTo(initialHp - attacker.Damage));
        }
    }
}
