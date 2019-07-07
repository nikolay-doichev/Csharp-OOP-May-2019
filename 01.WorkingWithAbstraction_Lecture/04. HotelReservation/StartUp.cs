using System;

namespace _04HotelReservation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] reservation = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            //50.25 5 Summer VIP
            decimal pricePerDay = decimal.Parse(reservation[0]);
            int numberOfDays = int.Parse(reservation[1]);
            Season season = default(Season);
            
            switch (reservation[2])
            {
                case "Autumn":
                    season = Season.Autumn;                    
                    break;
                case "Spring":
                    season = Season.Spring;
                    break;
                case "Winter":
                    season = Season.Winter;           
                    break;
                case "Summer":
                    season = Season.Summer;             
                    break;
                default:
                    break;
            }

            Discount discount = default(Discount);

            if (reservation.Length == 4)
            {
                switch (reservation[3])
                {
                    case "VIP":
                        discount = Discount.VIP;
                        break;
                    case "SecondVisit":
                        discount = Discount.SecondVisit;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                discount = Discount.None;
            }                 

            Console.WriteLine($"{PriceCalculator.CalculatePrice(pricePerDay, numberOfDays, season, discount):F2}");
        }
    }
}
