using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;

namespace CarLibrary
{
    public class LinqRequests
    {
        public static double FindMaxCostOfOffroadCars(Transport[] transports)
        {
            return transports
                .OfType<OffroadCar>()
                .Max(t => t.Cost);
        }

        public static double FindAvgSpeedOfPassengerCars(Transport[] transports)
        {
            IEnumerable<PassengerCar> passengerCars = transports.OfType<PassengerCar>();
            return passengerCars.Any() ? passengerCars.Average(t => t.MaxSpeed) : 0;
        }

        public static double FindCountOfTrucksWithExceedingCapacity(Transport[] transports, double capacity)
        {
            return transports.OfType<Truck>().Count(t => t.LoadCapacity > capacity);
        }
    }
}
