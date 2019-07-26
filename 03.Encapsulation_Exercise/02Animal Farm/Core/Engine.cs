using AnimalFarm.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(
                    "Chicken {0} (age {1}) can produce {2} eggs per day.",
                    chicken.Name,
                    chicken.Age,
                    chicken.ProductPerDay);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }            
        }
    }
}
