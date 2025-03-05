using CarLab;
using CarLibrary;
namespace CarLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transport t = new Transport();
            t.Show();
            PassengerCar p1 = new PassengerCar();
            p1.Show();
            PassengerCar p2 = new PassengerCar(3, "Mercedez", 1990, "Чёрный", 3000000, 140, 4, 120);
            p2.Show();
            OffroadCar c1 = new OffroadCar();
            c1.Show();
            OffroadCar c2 = new OffroadCar(16, "Bugatti", 2015, "Белый", 4500000, 320, true, "Пикап");
            c2.Show();
            Truck t1 = new Truck();
            t1.Show();
            Truck t2 = new Truck(28, "Chevrolet", 1997, "Золотой", 2000000, 200, 1500);
            t2.Show();

            Transport[] arr1 = new Transport[12];
            for (int i = 0; i < arr1.Length / 4; i++)
            {
                Transport c = new Transport();
                c.RandomCreate();
                arr1[i] = c;
            }

            for (int i = arr1.Length / 4; i < arr1.Length / 2; i++)
            {
                PassengerCar c = new PassengerCar();
                c.RandomCreate();
                arr1[i] = c;
            }

            for (int i = arr1.Length / 2; i < 3 * arr1.Length / 4; i++)
            {
                OffroadCar c = new OffroadCar();
                c.RandomCreate();
                arr1[i] = c;
            }

            for (int i = 3 * arr1.Length / 4; i < arr1.Length; i++)
            {
                Truck c = new Truck();
                c.RandomCreate();
                arr1[i] = c;
            }

            foreach (Transport item in arr1)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            double maxCost = LinqRequests.FindMaxCostOfOffroadCars(arr1);
            double avgSpeed = LinqRequests.FindAvgSpeedOfPassengerCars(arr1);
            double relevantTrucks = LinqRequests.FindCountOfTrucksWithExceedingCapacity(arr1, 12000);

            Console.WriteLine("Результаты запросов: ");
            Console.WriteLine($"Стоимость самого дорогого внедорожника - {maxCost} р.");
            Console.WriteLine($"Средняя скорость всех легковых автомобилей равна: {avgSpeed} км/ч.");
            Console.WriteLine($"Количество грузовиков, грузоподъёмность которых больше 12000 кг: {relevantTrucks}.");

            Transport[] arr2 = new Transport[4];
            for (int i = 0; i < arr2.Length / 4; i++)
            {
                Console.WriteLine($"Заполнение данных автомобиля под номером {i + 1}");
                Transport c = new Transport();
                c.ConsoleCreate();
                arr2[i] = c;
                Console.WriteLine();
            }

            for (int i = arr2.Length / 4; i < arr2.Length / 2; i++)
            {
                Console.WriteLine($"Заполнение данных автомобиля под номером {i + 1}");
                PassengerCar c = new PassengerCar();
                c.ConsoleCreate();
                arr2[i] = c;
                Console.WriteLine();

            }

            for (int i = arr2.Length / 2; i < 3 * arr2.Length / 4; i++)
            {
                Console.WriteLine($"Заполнение данных автомобиля под номером {i + 1}");
                OffroadCar c = new OffroadCar();
                c.ConsoleCreate();
                arr2[i] = c;
                Console.WriteLine();
            }

            for (int i = 3 * arr2.Length / 4; i < arr2.Length; i++)
            {
                Console.WriteLine($"Заполнение данных автомобиля под номером {i + 1}");
                Truck c = new Truck();
                c.ConsoleCreate();
                arr2[i] = c;
                Console.WriteLine();
            }

            foreach (Transport item in arr2)
            {
                Console.WriteLine(item);
            }

            Transport tr1 = new Transport(5, "Ауди", 2006, "Белый", 12000000, 200);
            Transport tr2 = new Transport();
            Console.WriteLine(tr1.Equals(tr2));

            Console.WriteLine("\nСортировка по брендам: ");
            Array.Sort(arr1);
            foreach (Transport item in arr1)
            {
                Console.WriteLine(item);
            }

            Transport searchItemByBrand = new Transport();
            searchItemByBrand.RandomCreate();
            Console.WriteLine($"Автомобиль, бренд которого нужно найти: {searchItemByBrand.Brand}");
            int objBrand = Array.BinarySearch(arr1, searchItemByBrand);

            if (objBrand >= 0)
            {
                Console.WriteLine($"\nАвтомобиль {arr1[objBrand]} найден на позиции {objBrand + 1}.");
            }
            else
            {
                Console.WriteLine("\nЭлемент не найден.");
            }

            Console.WriteLine("\nСортировка по году выпуска: ");
            Array.Sort(arr1, new SortByYearComparator());
            foreach (Transport item in arr1)
            {
                Console.WriteLine(item);
            }

            Transport searchItemByYear = new Transport();
            searchItemByYear.RandomCreate();
            Console.WriteLine($"Год выпуска, по которому нужно найти автомобиль в списке: {searchItemByYear.Year}");
            int objYear = Array.BinarySearch(arr1, searchItemByYear);

            if (objYear >= 0)
            {
                Console.WriteLine($"\nАвтомобиль {arr1[objYear]} найден на позиции {objYear + 1}.");
            }
            else
            {
                Console.WriteLine("\nЭлемент не найден.");
            }

            ICreateItems[] items = new ICreateItems[4];

            for (int i = 0; i < items.Length; i++)
            {
                if (i % 2 == 0)
                {
                    items[i] = new DialClock();

                    if (i == 0)
                    {
                        items[i].RandomCreate();
                    }
                    else
                    {
                        items[i].ConsoleCreate();
                    }
                }
                else
                {
                    items[i] = new Transport();

                    if (i == 1)
                    {
                        items[i].RandomCreate();
                    }
                    else
                    {
                        items[i].ConsoleCreate();
                    }
                }
            }

            foreach (var i in items)
            {
                Console.WriteLine(i.ToString());
            }

            Transport tr = new Transport(1, "Mercedez", 2011, "Чёрный", 4000000, 130);
            Transport clon = (Transport)tr.Clone();
            Transport copy = (Transport)tr.ShallowCopy();
            Console.WriteLine(tr);
            Console.WriteLine("Клон: " + clon);
            Console.WriteLine("Копия: " + copy + "\n");

            tr.ID.Id = 10;
            tr.Brand = "Chevrolet";
            tr.Year = 2010;
            tr.Colour = "Белый";
            tr.Cost = 2500000;
            tr.Clearance = 180;

            Console.WriteLine(tr);
            Console.WriteLine("Клон: " + clon);
            Console.WriteLine("Копия: " + copy);
        }
    }
}
