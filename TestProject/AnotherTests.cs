using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class AnotherTests
    {
        [TestMethod]
        public void ConstructorShouldInitializeId()
        {
            // Arrange
            int expectedId = 123;
            // Act
            IdNumber idNumber = new IdNumber(expectedId);
            // Assert
            Assert.AreEqual(expectedId, idNumber.Id);
        }

        [TestMethod]
        public void EqualsWithEqualIdsShouldReturnTrue()
        {
            // Arrange
            IdNumber idNumber1 = new IdNumber(1);
            IdNumber idNumber2 = new IdNumber(1);
            // Act
            bool areEqual = idNumber1.Equals(idNumber2);
            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void EqualsWithDifferentIdsShouldReturnFalse()
        {
            // Arrange
            IdNumber idNumber1 = new IdNumber(1);
            IdNumber idNumber2 = new IdNumber(2);
            // Act
            bool areEqual = idNumber1.Equals(idNumber2);
            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void EqualsWithNullShouldReturnFalse()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(1);
            // Act
            bool areEqual = idNumber.Equals(null);
            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void GetHashCodeShouldReturnsameValueForEqualObjects()
        {
            // Arrange
            IdNumber idNumber1 = new IdNumber(1);
            IdNumber idNumber2 = new IdNumber(1);
            // Act
            int hash1 = idNumber1.GetHashCode();
            int hash2 = idNumber2.GetHashCode();
            // Assert
            Assert.AreEqual(hash1, hash2);
        }
    }
}
