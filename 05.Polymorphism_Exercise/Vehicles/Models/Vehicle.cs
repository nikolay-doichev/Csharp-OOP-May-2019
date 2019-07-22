using System;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            private set
            {
                if (value>this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                this.fuelQuantity = value;
            }
        }
        public double FuelConsumption { get; protected set;}
        public double TankCapacity { get; private set; }
        protected abstract double AdditionalConsumption { get; }
        public void Drive(double distance)
        {            
            double fuelForDrive = (this.FuelConsumption + this.AdditionalConsumption) * distance;
            double fuelAfterDrive = this.FuelQuantity - fuelForDrive;

            if (fuelAfterDrive < 0)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity = fuelAfterDrive;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (fuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit { liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: { this.FuelQuantity:F2}";
        }
    }
}
