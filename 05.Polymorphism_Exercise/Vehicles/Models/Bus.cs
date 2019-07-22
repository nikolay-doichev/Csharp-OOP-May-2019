using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITIONER = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }

        protected override double AdditionalConsumption => AIR_CONDITIONER;
       
        public void DriveWithoutAirConditionar(double distance)
        {
            this.FuelConsumption -= AIR_CONDITIONER;  
            
        }
    }
}
