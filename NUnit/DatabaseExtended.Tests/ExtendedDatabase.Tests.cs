using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowsExceptio_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
               this. extendedDatabase.Add(new Person(i, $"Username{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(16, "InvalidUsername")));
        }

        [Test]
        public void Add_ThrowException_WhenUsernameExists()
        {
            this.extendedDatabase.Add(new Person(1, "User"));
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(1, "User")));
        }

        [Test]
        public void Add_ThrowException_WhenIdExists()
        {
            this.extendedDatabase.Add(new Person(1, "User1"));
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(new Person(1, "User2")));
        }

        [Test]
        public void Add_IncreasesCount_WhenUsesrIsValid()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Users{i}"));
            }

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(n));
        }

        [Test]
        public void Remove_ThrowException_WhenDatabaseIsEmoty() 
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDatabase()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"User{i}"));
            }

            this.extendedDatabase.Remove();
            Assert.AreEqual(this.extendedDatabase.Count, n - 1);
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowException_WhenUserIsNotValid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(username));
        }

        [Test]
        public void FindByusername_ThrowException_WhenUsernameDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindByUsername("Username"));
        }

        [Test]
        public void FindByUsername_ReturnExpectedUser_WhenUserExists()
        {
            Person person = new Person(1, "Petar");
            this.extendedDatabase.Add(person);
            Person dbperson = this.extendedDatabase.FindByUsername(person.UserName);
            Assert.AreEqual(person, dbperson);
        }

        [Test]
        [TestCase (-1)]
        [TestCase(-30)]
        public void FindById_ThrowsException_WhenIdIsLessThanZero(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(id));
        }

        [Test]
        public void FinfById_ThrowsException_WhenUserWithIdDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(100));
        }

        [Test]
        public void FindById_ReturnsExpectedUsers_WhenUserExists()
        {
            Person person = new Person(1, "Petar");
            this.extendedDatabase.Add(person);
            Person dbPerson = this.extendedDatabase.FindById(person.Id);
            Assert.AreEqual(person, dbPerson);
        }

        [Test]
        public void Ctor_ThrowsException_WhenDatabaseCapacityIsExceeded()
        {
            Person[] arguments = new Person[17];
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"User{i}");
            }

            Assert.Throws<ArgumentException>(() =>
                   this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(arguments));
        }

        [Test]
        public void Ctor_AddInitialPeopleToDatabase()
        {
            Person[] arguments = new Person[5];
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"User{i}");
            }

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(arguments);

            Assert.AreEqual(this.extendedDatabase.Count, arguments.Length);

            foreach (var person in arguments)
            {
                Person dbPerson = this.extendedDatabase.FindById(person.Id);
                Assert.AreEqual(person, dbPerson);
            }
         
        }
    }
}