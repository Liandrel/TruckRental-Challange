using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRentalLogicLibrary
{
    public static class RentalLogic
    {
        public static void PopulateCarList(List<CarModel> CarList)
        {
            CarList.Add(new CarModel("GMC", "Canyon"));
            CarList.Add(new CarModel("Mitsubishi", "Triton"));
            CarList.Add(new CarModel("Nissan", "Navara"));
            CarList.Add(new CarModel("Nissan", "Titan"));
            CarList.Add(new CarModel("Volkswagen", "Amarok"));
        }
        public static void RentCar(CarModel car)
        {
            car.IsRented = true;
            car.StartRentDate = DateTime.Now;
        }
        public static decimal ReturnCar(CarModel car, DateTime returnRentDate)
        {
            decimal output;

            car.IsRented = false;
            output = CalculatePrice(car, returnRentDate);

            return output;
        }

        private static decimal CalculatePrice(CarModel car, DateTime returnRentDate)
        {
            decimal output = 0;

            TimeSpan timeRented = returnRentDate.Subtract(car.StartRentDate);
            int hours = (int)timeRented.TotalMinutes / 60;
            int minutes = (int)timeRented.TotalMinutes % 60;
            if(minutes > 10)
            {
                hours++;
            }
            car.StartRentDate = DateTime.Today;

            if(hours >= 1)
            {
                output = 25;
            }
            output += --hours * 50;

            return output;
        }
    }
}
