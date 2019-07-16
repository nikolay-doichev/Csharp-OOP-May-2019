namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffePrice = 3.50m;
        private const double CoffeeMilliliters = 50;
        public Coffee(string name, double caffeine) : base(name, CoffePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
