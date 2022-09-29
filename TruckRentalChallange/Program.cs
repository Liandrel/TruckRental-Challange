using TruckRentalChallange;
using TruckRentalLogicLibrary;

List<CarModel> carsForRent = new();
RentalLogic.PopulateCarList(carsForRent);




string option = String.Empty;
do
{
    Console.Clear();
    Console.WriteLine("Do You want to rent or return a car: ");
    Console.WriteLine("1.Rent");
    Console.WriteLine("2.Return");
    Console.WriteLine("3.Exit");

     option = Console.ReadLine();

    switch (option.ToLower())
    {
        case "rent":
            UIDialogs.RentCarDialog(carsForRent);
            break;
        case "return":
            UIDialogs.ReturnCarDialog(carsForRent);
            break;
        case "exit":
            break;
        default:
            Console.Clear();
            Console.WriteLine("U need to choose 1,2 or 3!");
            break;
    } 
} while (option.ToLower() != "exit" );



