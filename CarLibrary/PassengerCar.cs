using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class PassengerCar : Transport
    {
        private int seatsNumber;
        private double maxSpeed;

        public int SeatsNumber
        {
            get { return seatsNumber; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество мест не может быть отрицательным.");
                seatsNumber = value;
            }
        }

        public double MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value <= 0 || value >= 1500)
                    throw new ArgumentOutOfRangeException("Несуществующая скорость автомобиля.");
                maxSpeed = value;
            }
        }

        public PassengerCar() : base() 
        {
            seatsNumber = 2;
            maxSpeed = 60;
        }

        public PassengerCar(int id, string brand, int year, string colour, double cost, double clearance, int seatsNumber, double maxSpeed) : base(id, brand, year, colour, cost, clearance) 
        {
            SeatsNumber = seatsNumber;
            MaxSpeed = maxSpeed;
        }

        public override void Show()
        {
            string show = $"{ID}, Бренд: {Brand}, Цвет: {Colour}, Год выпуска: {Year}, Стоимость: {Cost} р, " +
                $"Дорожный просвет: {Clearance} мм, Количество мест: {SeatsNumber}, Максимальная скорость: {MaxSpeed} км/ч.";
            Console.WriteLine(show);
        }

        public override void ConsoleCreate()
        {
            base.ConsoleCreate();

            Console.Write("Введите количество мест в автомобиле: ");
            SeatsNumber = int.Parse(Console.ReadLine()!);

            Console.Write("Введите максимальную скорость автомобиля: ");
            MaxSpeed = double.Parse(Console.ReadLine()!);
        }

        public override void RandomCreate()
        {
            base.RandomCreate();
            SeatsNumber = rnd.Next(1, 10);
            MaxSpeed = rnd.Next(20, 1500);
        }

        public override string ToString()
        {
            return base.ToString() + $", Количество мест: {SeatsNumber}, Максимальная скорость: {MaxSpeed} км/ч.";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not PassengerCar) return false;
            return base.Equals(obj) && SeatsNumber == ((PassengerCar)obj).SeatsNumber && MaxSpeed == ((PassengerCar)obj).MaxSpeed;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode, SeatsNumber, MaxSpeed);
        }
    }
}
