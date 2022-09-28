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
            RentCarDialog();
            break;
        case "return":
            ReturnCarDialog();
            break;
        case "exit":
            break;
        default:
            Console.Clear();
            Console.WriteLine("U need to choose 1,2 or 3!");
            break;
    } 
} while (option.ToLower() != "exit" );

void ReturnCarDialog()
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
            Console.WriteLine($"You owe: {billValue} $");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Pick Correct car");
        }
    } while (isACar == false) ;
}

void RentCarDialog()
{
    Console.Clear();
    bool isACar;
    do
    {
        Console.WriteLine("List of Cars for rent:");
        carsForRent.Where(car=>car.IsRented == false).ToList().ForEach(car => Console.WriteLine($"{car.Producent}  {car.Model}"));


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

