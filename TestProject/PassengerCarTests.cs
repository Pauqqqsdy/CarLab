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
        private PassengerCar car = new PassengerCar(1, "Scania", 2022, "Red", 2000000, 250, 2, 150);

        [TestMethod]
        public void PassengerCarConstructorShouldInitializeProperties()
        {
            // Arrange
            var passengerCar = new PassengerCar();
            // Assert
            Assert.AreEqual(2, passengerCar.SeatsNumber);
            Assert.AreEqual(60, passengerCar.MaxSpeed);
        }

        [TestMethod]
        public void EqualsSameValuesReturnsTrue()
        {
            var otherCar = new PassengerCar(1, "Scania", 2022, "Red", 2000000, 250, 2, 150);
            Assert.IsTrue(car.Equals(otherCar));
        }

        [TestMethod]
        public void EqualsDifferentValuesReturnsFalse()
        {
            var otherCar = new PassengerCar(2, "Honda", 2021, "Red", 15000, 140, 4, 170);
            Assert.IsFalse(car.Equals(otherCar));
        }

        [TestMethod]
        public void ToStringReturnsCorrectString()
        {
            // Arrange
            var car = new PassengerCar
            {
                MaxSpeed = 60
            };
            // Act
            string result = car.ToString();
            // Assert
            string expected = "Максимальная скорость: 60 км/ч.";
            Assert.IsTrue(result.Contains(expected), $"Результат {result} равен {expected}.");
        }
    }
}
