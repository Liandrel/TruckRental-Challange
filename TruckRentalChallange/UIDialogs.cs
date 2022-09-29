using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckRentalLogicLibrary;

namespace TruckRentalChallange
{
    public static class UIDialogs
    {
        public static void ReturnCarDialog(List<CarModel> carsForRent)
        {
            Console.Clear();
            bool isACar;

            do
            {
                Console.WriteLine("List of Cars to return");
                carsForRent.Where(car => car.IsRented == true).ToList().ForEach(car => Console.WriteLine($"{car.Producent}  {car.Model}"));

                Console.Write("Which Car do you want to return: ");
                string line = Console.ReadLine();

                isACar = carsForRent.Exists(car => car.Producent == line.Split()[0] && car.Model == line.Split()[1]);
                if (isACar == true)
                {
                    CarModel pickedCar = carsForRent.Where(car => car.Producent == line.Split()[0] && car.Model == line.Split()[1]).First();
                    Console.Write("Date of return: ");
                    string returnDateString = Console.ReadLine();
                    DateTime returnDate = DateTime.ParseExact(returnDateString, "g", null);
                    decimal billValue = RentalLogic.ReturnCar(pickedCar, returnDate);
                    Console.WriteLine($"You owe {billValue:C}");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Pick Correct car");
                }
            } while (isACar == false);
        }

        public static void RentCarDialog(List<CarModel> carsForRent)
        {
            Console.Clear();
            bool isACar;
            do
            {
                Console.WriteLine("List of Cars for rent:");
                carsForRent.Where(car => car.IsRented == false).ToList().ForEach(car => Console.WriteLine($"{car.Producent}  {car.Model}"));


                Console.Write("Which Car do you want to rent: ");
                string line = Console.ReadLine();


                isACar = carsForRent.Exists(car => car.Producent == line.Split()[0] && car.Model == line.Split()[1]);
                if (isACar == true)
                {
                    CarModel pickedCar = carsForRent.Where(car => car.Producent == line.Split()[0] && car.Model == line.Split()[1]).First();
                    RentalLogic.RentCar(pickedCar);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Pick Correct car");
                }
            } while (isACar == false); ;


        }
    }
}
