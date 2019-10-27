using System;
using MortalEngines.Core;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachinesManager mn = new MachinesManager();

            Console.WriteLine(mn.HirePilot("Pesho"));
            Console.WriteLine(mn.ManufactureFighter("F1", 100, 200));
            Console.WriteLine(mn.ManufactureTank("T1", 300, 400));

            Console.WriteLine(mn.EngageMachine("Pesho", "F1"));
            Console.WriteLine(mn.EngageMachine("Pesho", "T1"));

            
            Console.WriteLine(mn.PilotReport("Pesho"));



        }
    }
}