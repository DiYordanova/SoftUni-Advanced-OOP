using NUnit.Framework;
using System;
using CarManager;

namespace Tests
{
    public class CarTests
    {
        private string make = "Make";
        private string model = "Model";
        private double fuelConsumption = 10.00;
        private double fuelCapacity = 100.00;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -5, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -5)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreasesFuelqAmount_WhenFuelAmountIsValid()
        {
            this.car.Refuel(this.car.FuelCapacity / 2);
            Assert.AreEqual(this.car.FuelAmount, this.car.FuelCapacity / 2);
        }

        [Test]
        public void Refuel_SetFuelAmountToCapacity_WhenCapacityIsExceeded()
        {
            this.car.Refuel(this.car.FuelCapacity * 1.2);
            Assert.AreEqual(this.car.FuelAmount, this.car.FuelCapacity);
        }

        [Test]
        public void Drive_ThrowsException_WhenFuelIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenDistanceIsValid()
        {
            this.car.Refuel(this.car.FuelCapacity);
            this.car.Drive(100);
            Assert.AreEqual(this.car.FuelAmount, this.car.FuelCapacity - this.car.FuelConsumption);
        }
                

        [Test]
        public void Drive_DecreaseFuelAmountToZero_WhenRequiredFuelIsEquelToFuelAmount1()
        {
            this.car.Refuel(100);            
            this.car.Drive(1000);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        public void FuelAmount_throwException_WhenNegativeValueIsPassed()
        {
            this.car.Refuel(this.car.FuelCapacity);
            double beforeDrive = this.car.FuelAmount;
            this.car.Drive(100);
            double afterDrive = this.car.FuelAmount;
            Assert.That(afterDrive, Is.LessThan(beforeDrive));
        }
    }
}