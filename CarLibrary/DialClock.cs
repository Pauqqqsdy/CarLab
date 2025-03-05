using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class DialClock : ICreateItems
    {
        protected static Random rnd = new Random();
        private int hours;
        private int minutes;
        private static int objectCount = 0;

        public int Hours
        {
            get { return this.hours; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Часы не могут быть отрицательными.");
                this.hours = value % 24;
            }
        }

        public int Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Минуты не могут быть отрицательными.");

                this.hours += value / 60;
                this.minutes = value % 60;
                this.hours %= 24;
            }
        }

        public DialClock()
        {
            objectCount++;
        }

        public DialClock(int hours)
        {
            this.Hours = hours;
            objectCount++;
        }

        public DialClock(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            objectCount++;
        }

        public double CalculateTheAngle()
        {
            double hoursAngle = hours % 12 * 30 + (minutes * 0.5);
            double minutesAngle = minutes * 6;
            double angle = Math.Abs(hoursAngle - minutesAngle);
            return angle > 180 ? 360 - angle : angle;
        }

        public string Show()
        {
            return $"Текущее время: {Hours:D2}:{Minutes:D2}. Угол между стрелками часов: {CalculateTheAngle()}";
        }

        public static int GetObjectCount() => objectCount;

        public static DialClock operator ++(DialClock clock)
        {
            clock.Minutes++;
            if (clock.Minutes >= 60)
            {
                clock.Minutes = 0;
                clock.Hours = (clock.Hours + 1) % 24;
            }
            return clock;
        }

        public static DialClock operator --(DialClock clock)
        {
            int newMinutes = clock.Minutes - 1;
            int newHours = clock.Hours;

            if (newMinutes < 0)
            {
                newMinutes = 59;
                newHours = (newHours - 1 + 24) % 24;
            }

            return new DialClock(newHours, newMinutes);
        }

        public static explicit operator bool(DialClock clock)
        {
            return clock.CalculateTheAngle() % 2.5 == 0;
        }

        public static implicit operator int(DialClock clock)
        {
            return (clock.Hours * 60) + clock.Minutes;
        }

        public static DialClock operator +(DialClock clock, int minutesToAdd)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes + minutesToAdd;
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }
        public static DialClock operator -(DialClock clock, int minutesToSubtract)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes - minutesToSubtract;
            if (totalMinutes < 0)
            {
                totalMinutes += 24 * 60;
            }
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        public static DialClock operator +(int minutesToAdd, DialClock clock)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes + minutesToAdd;
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        public static DialClock operator -(int minutesToSubtract, DialClock clock)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes;
            totalMinutes -= minutesToSubtract;
            if (totalMinutes < 0)
            {
                totalMinutes += 24 * 60;
            }
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not DialClock) return false;
            DialClock other = (DialClock)obj;
            return Hours == other.Hours && Minutes == other.Minutes;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes);
        }

        public void ConsoleCreate()
        {
            Console.Write("Введите часы: ");
            Hours = int.Parse(Console.ReadLine()!);

            Console.Write("Введите минуты: ");
            Minutes = int.Parse(Console.ReadLine()!);
        }

        public void RandomCreate()
        {
            int randomHours = rnd.Next(0, 24);
            int randomMinutes = rnd.Next(0, 60);
            Hours = randomHours;
            Minutes = randomMinutes;
        }
        public override string ToString()
        {
            return $"Время: {Hours:D2}:{Minutes:D2}, Угол между часовыми стрелками: {CalculateTheAngle()}";
        }
    }
}
