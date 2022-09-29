using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRentalLogicLibrary
{
    public static class Pricing
    {
        public static int DiscountedStartMinutes { get; set; } = 60;
        public static decimal DiscountedStartPrice { get; set; } = 25M;
        public static decimal HourlyRate { get; set; } = 50M;
        public static decimal dailyWeekdayRate { get; set; } = 400M;
        public static decimal dailyWeekendRate { get; set; } = 200M;
    }
}
