using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(3));
        }

        [Test]
        public void Add_IncreasesDatabaseCout_WhenAddIsValidOperation()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                this.database.Add(123);
            }
            Assert.That(this.database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_AddElementsToDatabase()
        {
            int element = 123;
            this.database.Add(element);
            int[] elements = this.database.Fetch();
            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void Remove_DecreasesDatabaseCount()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                this.database.Add(i);
            }

            this.database.Remove();
            Assert.AreEqual(this.database.Count, n - 1);
        }

        [Test]
        public void Remove_DecreasesElementFromDatabase()
        {
            this.database.Add(1);
            this.database.Add(2);
            this.database.Add(3);           
            this.database.Remove();
            int[] elements = this.database.Fetch();
            Assert.IsFalse(elements.Contains(3));
        }

        [Test]
        public void Fetch_ReturnDatabaseCopyInsteadOfReference()
        {
            this.database.Add(1);
            this.database.Add(2);

            int[] firstCopy = this.database.Fetch();

            this.database.Add(3);

            int[] secondCopy = this.database.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void Counts_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(this.database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsException_WhenDatabaseCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() =>
                   this.database = new Database.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));                         
        }

        [Test]
        public void Ctor_AddsElementsToDatabase()
        {
            int[] arr = new[] { 1, 2, 3 };
            this.database = new Database.Database(arr);
            Assert.That(this.database.Count, Is.EqualTo(arr.Length));
            Assert.That(this.database.Fetch(), Is.EquivalentTo(arr));
        }
    }
}