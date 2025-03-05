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
    public class OffroadCarTests
    {
        private OffroadCar car = new OffroadCar(1, "Toyota", 2022, "Blue", 20000, 150, true, "Buggy");
        [TestMethod]
        public void ConstructorSetsPropertiesCorrectly()
        {
            Assert.AreEqual("Toyota", car.Brand);
            Assert.AreEqual(2022, car.Year);
            Assert.AreEqual("Blue", car.Colour);
            Assert.AreEqual(20000, car.Cost);
            Assert.AreEqual(150, car.Clearance);
            Assert.IsTrue(car.AllWheelDrive);
            Assert.AreEqual("Buggy", car.OffroadType);
        }

        [TestMethod]
        public void EqualsEqualCarsShouldReturnTrue()
        {
            OffroadCar anotherCar = new OffroadCar(1, "Toyota", 2022, "Blue", 20000, 150, true, "Buggy");
            Assert.IsTrue(car.Equals(anotherCar));
        }

        [TestMethod]
        public void EqualsDifferentCarsShouldReturnFalse()
        {
            OffroadCar anotherCar = new OffroadCar(2, "Nissan", 2021, "Red", 18000, 220, false, "Пикап");
            Assert.IsFalse(car.Equals(anotherCar));
        }
    }
}
