using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        //•	AddAstronaut {astronautType} {astronautName}
                        string astronautType = input[1];
                        string astronautName = input[2];

                        writer.WriteLine(controller.AddAstronaut(astronautType, astronautName));
                        
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        //•	AddPlanet {planetName} {item1} {item2}… {itemN}
                        string planetName = input[1];
                        string[] items = input.Skip(2).ToArray();

                        writer.WriteLine(controller.AddPlanet(planetName,items));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        //•	RetireAstronaut {astronautName}
                        string astronautName = input[1];

                        writer.WriteLine(this.controller.RetireAstronaut(astronautName));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        //•	ExplorePlanet {planetName}
                        string planetName = input[1];

                        writer.WriteLine(this.controller.ExplorePlanet(planetName));
                    }
                    else if(input[0] == "Report")
                    {
                        writer.WriteLine(this.controller.Report().ToString());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
