using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class TruckTests
    {
        private Truck truck = new Truck(1, "Scania", 2022, "Red", 2000000, 250, 15000);
        [TestMethod]
        public void LoadCapacitySetValidValueUpdatesValue()
        {
            truck.LoadCapacity = 18000;
            Assert.AreEqual(18000, truck.LoadCapacity);
        }

        [TestMethod]
        public void TruckConstructorWithoutParametersSetsDefaultLoadCapacity()
        {
            Truck defaultTruck = new Truck();
            Assert.AreEqual(20000, defaultTruck.LoadCapacity);
        }

        [TestMethod]
        public void TruckConstructorWithParametersSetsAllProperties()
        {
            Assert.AreEqual("Scania", truck.Brand);
            Assert.AreEqual(2022, truck.Year);
            Assert.AreEqual("Red", truck.Colour);
            Assert.AreEqual(2000000, truck.Cost);
            Assert.AreEqual(250, truck.Clearance);
            Assert.AreEqual(15000, truck.LoadCapacity);
        }

        [TestMethod]
        public void EqualsSameInstancesReturnsTrue()
        {
            Truck anotherTruck = new Truck(1, "Scania", 2022, "Red", 2000000, 250, 15000);
            Assert.IsTrue(truck.Equals(anotherTruck));
        }

        [TestMethod]
        public void EqualsDifferentInstancesReturnsFalse()
        {
            Truck anotherTruck = new Truck(2, "Volvo", 2021, "Blue", 1800000, 200, 14000);
            Assert.IsFalse(truck.Equals(anotherTruck));
        }

        [TestMethod]
        public void GetHashCodeSameValuesReturnsSameHash()
        {
            Truck anotherTruck = new Truck(1, "Scania", 2022, "Red", 2000000, 250, 15000);
            Assert.AreEqual(truck.GetHashCode(), anotherTruck.GetHashCode());
        }
    }
}
