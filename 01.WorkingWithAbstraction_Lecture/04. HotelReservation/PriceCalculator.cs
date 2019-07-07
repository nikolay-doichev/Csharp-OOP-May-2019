using System;
using System.Collections.Generic;
using System.Text;

namespace _04HotelReservation
{
    public enum Season
    {
        Spring = 2,
        Summer = 4,
        Autumn = 1,
        Winter = 3
    };
    public enum Discount
    {
        None,
        SecondVisit = 10,
        VIP = 20
    };
    public static class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay, int numberOfDays, Season season, Discount discount)
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;
            decimal priceBeforeDiscount = numberOfDays * pricePerDay * multiplier;
            decimal discountedAmount =
                         priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }  
    }
}
