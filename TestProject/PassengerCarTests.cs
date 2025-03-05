using CarLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class PassengerCarTests
    {
        private PassengerCar car = new PassengerCar(1, "Toyota", 2022, "Blue", 20000, 150, 5, 180);
        [TestMethod]
        public void ConstructorWithValidParametersSetsPropertiesCorrectly()
        {
            Assert.AreEqual("Toyota", car.Brand);
            Assert.AreEqual(2022, car.Year);
            Assert.AreEqual("Blue", car.Colour);
            Assert.AreEqual(20000, car.Cost);
            Assert.AreEqual(150, car.Clearance);
            Assert.AreEqual(5, car.SeatsNumber);
            Assert.AreEqual(180, car.MaxSpeed);
        }

        [TestMethod]
        public void EqualsSameValuesReturnsTrue()
        {
            var otherCar = new PassengerCar(1, "Toyota", 2022, "Blue", 20000, 150, 5, 180);
            Assert.IsTrue(car.Equals(otherCar));
        }

        [TestMethod]
        public void EqualsDifferentValuesReturnsFalse()
        {
            var otherCar = new PassengerCar(2, "Honda", 2021, "Red", 15000, 140, 4, 170);
            Assert.IsFalse(car.Equals(otherCar));
        }
    }
}
