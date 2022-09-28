using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRentalLogicLibrary
{
    public class CarModel
    {
        public string Producent { get; set; }
        public string Model { get; set; }
        public bool IsRented { get; set; } = false;
        public DateTime StartRentDate { get; set; } 

        public CarModel(string producent, string model)
        {
            this.Producent = producent;
            this.Model = model;
        }
        
    }
}
