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
            output = CalculateAmmountOwed(car.StartRentDate, returnRentDate);

            return output;
        }

        private static decimal CalculateAmmountOwed(DateTime startDate, DateTime endDate)
        {
            decimal output = 0;

            TimeSpan rentalTime = endDate.Subtract(startDate);

            if (rentalTime.TotalMinutes <= Pricing.DiscountedStartMinutes)
            {
                output = Pricing.DiscountedStartPrice;
            }
            else 
            {
                decimal calculatedTotalCostByHourly = Pricing.DiscountedStartPrice + 
                   ((int)Math.Ceiling((rentalTime.TotalMinutes - Pricing.DiscountedStartMinutes) / 60.0) * Pricing.HourlyRate);
                if(calculatedTotalCostByHourly <= IdentifyDailyRate(startDate))
                {
                    output = calculatedTotalCostByHourly;
                }
                else
                {
                    TimeSpan rentalDays = endDate.Date.Subtract(startDate.Date);
                    int totalRentalDays = rentalDays.Days;
                    if (endDate.Hour >=12)
                    {
                        totalRentalDays += 1;
                    }

                    decimal calculatedDailyPrice = 0;

                    for (int i = 0; i < totalRentalDays; i++)
                    {
                        calculatedDailyPrice += IdentifyDailyRate(startDate.AddDays(i));
                    }
                    output = calculatedDailyPrice;
                }

            }

            return output;
        }
        private static decimal IdentifyDailyRate(DateTime day)
        {
            decimal output = Pricing.dailyWeekdayRate;
            
            if(day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
            {
                output = Pricing.dailyWeekendRate;
            }

            return output;
        }
    }
}
