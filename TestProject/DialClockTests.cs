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
        public void ConstructorShouldInitializeWithGivenHoursAndMinutes()
        {
            // Arrange
            int hours = 10;
            int minutes = 30;
            // Act
            var clock = new DialClock(hours, minutes);
            // Assert
            Assert.AreEqual(hours, clock.Hours);
            Assert.AreEqual(minutes, clock.Minutes);
        }

        [TestMethod]
        public void SetHoursShouldSetHoursCorrectly()
        {
            // Arrange
            var clock = new DialClock();
            // Act
            clock.Hours = 15;
            // Assert
            Assert.AreEqual(15, clock.Hours);
        }

        [TestMethod]
        public void SetHoursShouldWrapAroundAfter24Hours()
        {
            // Arrange
            var clock = new DialClock();
            // Act
            clock.Hours = 25;
            // Assert
            Assert.AreEqual(1, clock.Hours);
        }

        [TestMethod]
        public void SetMinutesShouldSetMinutesCorrectly()
        {
            // Arrange
            var clock = new DialClock();
            // Act
            clock.Minutes = 45;
            // Assert
            Assert.AreEqual(45, clock.Minutes);
        }

        [TestMethod]
        public void SetMinutesShouldWrapAroundAfter60Minutes()
        {
            // Arrange
            var clock = new DialClock();
            // Act
            clock.Minutes = 75;
            // Assert
            Assert.AreEqual(15, clock.Minutes);
            Assert.AreEqual(1, clock.Hours);
        }

        [TestMethod]
        public void CalculateTheAngleShouldReturnCorrectAngle()
        {
            // Arrange
            var clock = new DialClock(3, 15);
            // Act
            var angle = clock.CalculateTheAngle();
            // Assert
            Assert.AreEqual(7.5, angle, 0.001);
        }

        [TestMethod]
        public void IncrementOperatorShouldIncrementTimeByOneMinute()
        {
            // Arrange
            var clock = new DialClock(23, 59);
            // Act
            clock++;
            // Assert
            Assert.AreEqual(0, clock.Hours);
            Assert.AreEqual(0, clock.Minutes);
        }

        [TestMethod]
        public void DecrementOperatorShouldDecrementTimeByOneMinute()
        {
            // Arrange
            var clock = new DialClock(0, 0);
            // Act
            clock--;
            // Assert
            Assert.AreEqual(23, clock.Hours);
            Assert.AreEqual(59, clock.Minutes);
        }

        [TestMethod]
        public void AddMinutesOperatorShouldAddMinutesCorrectly()
        {
            // Arrange
            var clock = new DialClock(10, 30);
            // Act
            clock = clock + 90;
            // Assert
            Assert.AreEqual(12, clock.Hours);
            Assert.AreEqual(0, clock.Minutes);
        }

        [TestMethod]
        public void SubtractMinutesOperatorShouldSubtractMinutesCorrectly()
        {
            // Arrange
            var clock = new DialClock(1, 15);
            // Act
            clock = clock - 30;
            // Assert
            Assert.AreEqual(0, clock.Hours);
            Assert.AreEqual(45, clock.Minutes);
        }

        [TestMethod]
        public void EqualsShouldBeEqualForSameTime()
        {
            // Arrange
            var clock1 = new DialClock(10, 30);
            var clock2 = new DialClock(10, 30);
            // Assert
            Assert.IsTrue(clock1.Equals(clock2));
        }

        [TestMethod]
        public void NotEqualsShouldReturnFalseForDifferentTimes()
        {
            // Arrange
            var clock1 = new DialClock(10, 30);
            var clock2 = new DialClock(11, 30);
            // Assert
            Assert.IsFalse(clock1.Equals(clock2));
        }

        [TestMethod]
        public void GetHashCodeShouldReturnSameHashForSameTime()
        {
            // Arrange
            var clock1 = new DialClock(10, 30);
            var clock2 = new DialClock(10, 30);
            // Assert
            Assert.AreEqual(clock1.GetHashCode(), clock2.GetHashCode());
        }
    }
}
