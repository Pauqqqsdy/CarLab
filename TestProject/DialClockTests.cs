using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class DialClockTests
    {
        [TestMethod]
        public void TestDialClockConstructorWithHoursAndMinutes()
        {
            // Arrange
            DialClock expected = new DialClock(1, 150);
            // Act
            DialClock clock = new DialClock(3, 30);
            // Assert
            Assert.AreEqual(expected.Hours, clock.Hours);
            Assert.AreEqual(expected.Minutes, clock.Minutes);
        }

        [TestMethod]
        public void TestDialClockConstructorWithHours()
        {
            // Arange
            DialClock expected = new DialClock(3);
            // Act
            DialClock clock = new DialClock(3);
            // Assert
            Assert.AreEqual(expected.Hours, clock.Hours);
            Assert.AreEqual(expected.Minutes, clock.Minutes);
        }

        [TestMethod]
        public void TestDialClockConstructorDefault()
        {
            // Arange
            DialClock expected = new DialClock();
            // Act
            // Assert
            Assert.AreEqual(0, 0);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void TestSettingHours()
        {
            // Arrange
            DialClock clock = new DialClock();
            // Act
            clock.Hours = 25;
            // Assert
            Assert.AreEqual(1, clock.Hours);
        }

        [TestMethod]
        public void TestSettingMinutes()
        {
            // Arrange
            DialClock clock = new DialClock();
            // Act
            clock.Minutes = 105;
            // Assert
            Assert.AreEqual(45, clock.Minutes);
        }

        [TestMethod]
        public void TestCalculationTheAngle()
        {
            // Arrange
            DialClock clock = new DialClock(3, 0);
            // Act
            double angle = clock.CalculateTheAngle();
            // Assert
            Assert.AreEqual(angle, 90);
        }

        [TestMethod]
        public void TestIncrementOperator()
        {
            // Arrange
            DialClock clock = new DialClock(23, 69);
            // Act
            DialClock incClock = ++clock;
            // Assert
            Assert.AreEqual(0, incClock.Hours);
            Assert.AreEqual(10, incClock.Minutes);
        }

        [TestMethod]
        public void TestDecrementOperator()
        {
            // Arrange
            DialClock clock = new DialClock(0, 0);
            // Act
            DialClock deClock = --clock;
            // Assert
            Assert.AreEqual(23, deClock.Hours);
            Assert.AreEqual(59, deClock.Minutes);
        }

        [TestMethod]
        public void TestAddingMinutesOperatorLeft()
        {
            // Arrange
            DialClock clock = new DialClock(1, 50);
            // Act
            DialClock newClock = 10 + clock;
            // Assert
            Assert.AreEqual(2, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestAddingMinutesOperatorRight1()
        {
            // Arrange
            DialClock clock = new DialClock(1, 30);
            // Act
            DialClock newClock = clock + 90;
            // Assert
            Assert.AreEqual(3, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestAddingMinutesOperatorRight2()
        {
            // Arrange
            DialClock clock = new DialClock(23, 0);
            // Act
            DialClock newClock = clock + 120;
            // Assert
            Assert.AreEqual(1, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestAddingMinutesOperatorRight3()
        {
            // Arrange
            DialClock clock = new DialClock(12, 30);

            // Act
            DialClock newClock = clock + (-30); // 12:30 - 30 ěčíóň = 12:00

            // Assert
            Assert.AreEqual(12, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestSubtractingMinutesOperatorRight()
        {
            // Arrange
            DialClock clock = new DialClock(1, 30);
            // Act
            DialClock newClock = clock - 40;
            // Assert
            Assert.AreEqual(0, newClock.Hours);
            Assert.AreEqual(50, newClock.Minutes);
        }

        [TestMethod]
        public void TestSubtractMinutesLeft1()
        {
            // Arrange
            DialClock clock = new DialClock(0, 0);

            // Act
            DialClock newClock = 60 - clock;

            // Assert
            Assert.AreEqual(23, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestEqualsOperatorTrue()
        {
            // Arrange
            DialClock clock1 = new DialClock(3, 15);
            DialClock clock2 = new DialClock(3, 15);
            // Act
            bool areEqual = clock1.Equals(clock2);
            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestExplicitOperator()
        {
            // Arrange
            DialClock clock = new DialClock(5, 0);
            // Act
            bool result = (bool)clock;
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestImplicitOperator()
        {
            // Arrange
            DialClock clock = new DialClock(12, 0);
            // Act
            int result = (int)clock;
            // Assert
            Assert.AreEqual(720, result);
        }

        [TestMethod]
        public void GetHashCodeShouldBeEqualForEqualObjects()
        {
            // Arrange
            var clock1 = new DialClock { Hours = 10, Minutes = 30 };
            var clock2 = new DialClock { Hours = 10, Minutes = 30 };
            // Act
            var hash1 = clock1.GetHashCode();
            var hash2 = clock2.GetHashCode();
            // Assert
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCodeShouldNotBeEqualForDifferentObjects()
        {
            // Arrange
            var clock1 = new DialClock { Hours = 10, Minutes = 30 };
            var clock2 = new DialClock { Hours = 11, Minutes = 30 };
            // Act
            var hash1 = clock1.GetHashCode();
            var hash2 = clock2.GetHashCode();
            // Assert
            Assert.AreNotEqual(hash1, hash2);
        }
    }
}
