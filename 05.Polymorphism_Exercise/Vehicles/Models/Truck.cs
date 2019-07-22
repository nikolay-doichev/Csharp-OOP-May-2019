namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double additionalConsumptionPerKm = 1.6;
        private const double refuelingCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        protected override double AdditionalConsumption => additionalConsumptionPerKm;

        public override void Refuel(double liters)
        {
            base.Refuel(liters * refuelingCoefficient);
        }
    }
}
