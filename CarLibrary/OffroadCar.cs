using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class OffroadCar : Transport
    {
        private bool allWheelDrive;
        private string? offroadType;

        static string[] OffroadTypes = { "Багги", "Пикап", "Кроссовер" };

        public string? OffroadType
        {
            get => offroadType;
            set
            {
                if (string.IsNullOrEmpty(value) || !value.Any(char.IsLetter))
                    throw new ArgumentException("Неверно заполненное поле вида внедорожника.");
                offroadType = value;
            }
        }

        public bool AllWheelDrive
        {
            get => allWheelDrive;
            set
            {
                if (value != true && value != false)
                    throw new ArgumentException("Неверное значение для полного привода.");
                allWheelDrive = value;
            }
        }

        public OffroadCar() : base()
        {
            allWheelDrive = false;
            offroadType = "Багги";
        }

        public OffroadCar(int id, string brand, int year, string colour, double cost, double clearance, bool allWheelDrive, string offroadType) : base(id, brand, year, colour, cost, clearance)
        {
            AllWheelDrive = allWheelDrive;
            OffroadType = offroadType;
        }

        public override void Show()
        {
            string show = $"{ID}, Бренд: {Brand}, Цвет: {Colour}, Год выпуска: {Year}, Стоимость: {Cost} р, " +
                $"Дорожный просвет: {Clearance} мм, Полный привод: {(allWheelDrive ? "да" : "нет")}, Тип внедорожника: {offroadType}.";
            Console.WriteLine(show);
        }

        public override void ConsoleCreate()
        {
            base.ConsoleCreate();
            Console.Write("Является ли автомобиль полноприводным? 1 - Да, 0 - Нет: ");
            string? input = Console.ReadLine();
            if (input == "1")
            {
                AllWheelDrive = true;
            }
            else if (input == "0")
            {
                AllWheelDrive = false;
            }
            Console.Write("Введите тип внедорожника: ");
            OffroadType = Console.ReadLine();
        }
        public override void RandomCreate()
        {
            base.RandomCreate();
            allWheelDrive = rnd.Next(0, 2) == 1;
            offroadType = OffroadTypes[rnd.Next(OffroadTypes.Length)];
        }

        public override string ToString()
        {
            return base.ToString() + $", Полный привод: {(allWheelDrive ? "да" : "нет")}, Тип внедорожника: {offroadType}.";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not OffroadCar) return false;
            return base.Equals(obj) && this.OffroadType == ((OffroadCar)obj).OffroadType && this.AllWheelDrive == ((OffroadCar)obj).AllWheelDrive;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode, OffroadType, AllWheelDrive);
        }
    }
}
