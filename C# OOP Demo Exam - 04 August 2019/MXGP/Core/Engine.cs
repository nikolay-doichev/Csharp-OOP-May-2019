using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Core.Contracts;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;
        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }
        public void Run()
        {
            while (true)
            {
                string[] inpuInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inpuInfo[0];

                try
                {
                    if (command == "CreateRider")
                    {
                        string name = inpuInfo[1];
                    
                        Console.WriteLine(championshipController.CreateRider(name));
                    }
                    else if (command == "CreateMotorcycle" )
                    {
                        //CreateMotorcycle {motorcycle type} {model} {horsepower}
                        string type = inpuInfo[1];
                        string model = inpuInfo[2];
                        int horsePower = int.Parse(inpuInfo[3]);

                        Console.WriteLine(championshipController.CreateMotorcycle(type, model, horsePower));
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        //AddMotorcycleToRider {rider name} {motorcycle name}
                        string riderName = inpuInfo[1];
                        string motorcycleName = inpuInfo[2];

                        Console.WriteLine(championshipController.AddMotorcycleToRider(riderName, motorcycleName));
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string raceName = inpuInfo[1];
                        string riderName = inpuInfo[2];


                        Console.WriteLine(championshipController.AddRiderToRace(raceName,riderName));
                    }
                    else if (command == "CreateRace")
                    {
                        string name = inpuInfo[1];
                        int laps = int.Parse(inpuInfo[2]);

                        Console.WriteLine(championshipController.CreateRace(name,laps));
                    }

                    else if (command=="StartRace")
                    {
                        string raceName = inpuInfo[1];

                        Console.WriteLine(championshipController.StartRace(raceName));
                    }
                    else if (command == "End")break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
