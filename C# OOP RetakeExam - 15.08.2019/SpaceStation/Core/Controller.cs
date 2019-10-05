using System;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Model;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Model;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int ExplorePlanetsCount = 0;

        private readonly IRepository<IAstronaut> astonautsRepository;
        private readonly IRepository<IPlanet> planetsRepository;
        private IMission mission;

        public Controller()
        {
            this.astonautsRepository = new AstronautRepository();
            this.planetsRepository = new PlanetRepository();

            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            IAstronaut astronaut = null;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;

                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;

                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;

                default:
                    break;
            }

            astonautsRepository.Add(astronaut);
            string result = $"Successfully added {type}: {astronautName}!";

            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName,items);
            planetsRepository.Add(planet);
            string result = $"Successfully added Planet: {planetName}!";

            return result;
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut retireAstronaut = this.astonautsRepository.Models.FirstOrDefault(a => a.Name == astronautName);

            if (retireAstronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            this.astonautsRepository.Remove(retireAstronaut);
            string result = $"Astronaut {astronautName} was retired!";

            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsForMission = this.astonautsRepository.Models.Where(a => a.Oxygen > 60).ToList();
            IPlanet planet = this.planetsRepository.Models.FirstOrDefault(p => p.Name == planetName);

            if (astronautsForMission.Count() == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            
            else
            {
                foreach (IAstronaut astronaut in astronautsForMission)
                {
                    mission.Explore(planet, astronautsForMission);
                }

                string result =
                    $"Planet: {planetName} was explored! Exploration finished with {astronautsForMission.Count()} dead astronauts!";
                ExplorePlanetsCount++;

                return result;
            }

            
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{ExplorePlanetsCount} planets were explored!");

            foreach (IAstronaut astronaut in this.astonautsRepository.Models)
            {
                sb.AppendLine("Astronauts info:");
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine("Bag items: none");
                }
                else
                {
                    foreach (string bagItem in astronaut.Bag.Items)
                    {
                        sb.AppendLine($"Bag items: {bagItem}");
                    }
                }
            }

            return sb.ToString().TrimEnd();

            //"{exploredPlanetsCount} planets were explored!
            //Astronauts info:
            //Name: { astronautName}
            //Oxygen: { astronautOxygen}
            //Bag items: { bagItem1, bagItem2, …, bagItemn} / none
            //    …
            //Name: { astronautName}
            //Oxygen: { astronautOxygen}
            //Bag items: { bagItem1, bagItem2, …, bagItemn} / none"

        }
    }
}