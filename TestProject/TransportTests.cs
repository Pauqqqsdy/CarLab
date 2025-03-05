using CarLibrary;
using CarLab;

namespace TestProject
{
    [TestClass]
    public class TransportTests
    {
        private Transport transport = new Transport();
        [TestMethod]
        public void DefaultConstructorShouldInitializeWithDefaultValues()
        {
            Assert.AreEqual("Лада", transport.Brand);
            Assert.AreEqual(2010, transport.Year);
            Assert.AreEqual("Синий", transport.Colour);
            Assert.AreEqual(150000, transport.Cost);
            Assert.AreEqual(115, transport.Clearance);
        }

        [TestMethod]
        public void ParameterizedConstructorShouldInitializeWithProvidedValues()
        {
            transport = new Transport(1, "Toyota", 2015, "Красный", 300000, 140);
            Assert.AreEqual("Toyota", transport.Brand);
            Assert.AreEqual(2015, transport.Year);
            Assert.AreEqual("Красный", transport.Colour);
            Assert.AreEqual(300000, transport.Cost);
            Assert.AreEqual(140, transport.Clearance);
        }

        [TestMethod]
        public void EqualsShouldReturnTrueWhenObjectsAreEqual()
        {
            transport = new Transport(4, "Audi", 2021, "Синий", 3000000, 160);
            var transport2 = new Transport(4, "Audi", 2021, "Синий", 3000000, 160);
            Assert.IsTrue(transport.Equals(transport2));
        }

        [TestMethod]
        public void EqualsShouldReturnFalseWhenObjectsAreNotEqual()
        {
            transport = new Transport(5, "Honda", 2017, "Красный", 1500000, 120);
            var transport2 = new Transport(6, "Honda", 2018, "Красный", 1500000, 120);
            Assert.IsFalse(transport.Equals(transport2));
        }

        [TestMethod]
        public void CloneShouldReturnASeparateInstanceWithSameValues()
        {
            transport = new Transport(7, "Chevrolet", 2022, "Зелёный", 3500000, 180);
            var clone = (Transport)transport.Clone();

            Assert.AreNotSame(transport, clone);
            Assert.AreEqual(transport.Brand, clone.Brand);
            Assert.AreEqual(transport.Colour, clone.Colour);
        }

        [TestMethod]
        public void RandomCreateShouldAssignRandomValues()
        {
            transport.RandomCreate();
            Assert.IsNotNull(transport.Brand);
            Assert.IsNotNull(transport.Colour);
            Assert.IsTrue(transport.Year >= 1885 && transport.Year <= 2025);
            Assert.IsTrue(transport.Cost > 250000 && transport.Cost < 50000000);
            Assert.IsTrue(transport.Clearance >= 10 && transport.Clearance <= 900);
        }
    }
}