using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        private List<Vehicle> vehicles; 
        public Engine()
        {
            this.vehicles = new List<Vehicle>();
        }

        public void Run()
        {
            //"Vehicle {initial fuel quantity} {liters per km} {tank capacity}"
            string[] carInfo = Console.ReadLine().Split(" ").Skip(1).ToArray();
            Vehicle car = new Car(double.Parse(carInfo[0]), double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            
            Vehicle truck = MakeTruck();

            Vehicle bus = MakeBus();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandsArgs = Console.ReadLine().Split(" ");
                string command = commandsArgs[0];
                string vehicleType = commandsArgs[1];
                double value = double.Parse(commandsArgs[2]);
                
                if (command == "Drive")
                {
                    try
                    {
                        if (vehicleType == "Car")
                        {
                            car.Drive(value);
                        }
                        else if(vehicleType == "Truck")
                        {
                            truck.Drive(value);
                        }
                        else if(vehicleType =="Bus")
                        {
                            bus.Drive(value);
                        }
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else
                        {
                            bus.Refuel(value);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
                else
                {
                    ((Bus)bus).DriveWithoutAirConditionar(value);                    
                }

            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }

        private static Vehicle MakeBus()
        {
            string[] makeBus = Console.ReadLine().Split(" ").Skip(1).ToArray();
            double fuelQuantity = double.Parse(makeBus[0]);
            double fuelConsumption = double.Parse(makeBus[1]);
            double fuelCapacity = double.Parse(makeBus[2]);
            Vehicle bus = new Bus(fuelQuantity, fuelConsumption, fuelCapacity);

            return bus;
        }

        private static Vehicle MakeTruck()
        {
            string[] makeTruck = Console.ReadLine().Split(" ").Skip(1).ToArray();
            double fuelQuantity = double.Parse(makeTruck[0]);
            double fuelConsumption = double.Parse(makeTruck[1]);
            double fuelCapacity = double.Parse(makeTruck[2]);
            Vehicle truck = new Truck(fuelQuantity, fuelConsumption, fuelCapacity);

            return truck;
        }

        private static Vehicle MakeCar()
        {
            string[] carInfo = Console.ReadLine().Split(" ").Skip(1).ToArray();
            double fuelQuantity = double.Parse(carInfo[0]);
            double fuelConsumption = double.Parse(carInfo[1]);
            double fuelCapacity = double.Parse(carInfo[2]);
            Vehicle car = new Car(fuelQuantity, fuelConsumption, fuelCapacity);
            return car;
        }
    }
}
