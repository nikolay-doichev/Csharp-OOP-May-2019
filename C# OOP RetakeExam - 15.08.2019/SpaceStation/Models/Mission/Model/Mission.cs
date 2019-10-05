using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission.Model
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut collectingAstronaut in astronauts)
            {
                if (collectingAstronaut.CanBreath)
                {
                    foreach (var planetItem in planet.Items.ToArray())
                    {
                        collectingAstronaut.Bag.Items.Add(planetItem);
                        collectingAstronaut.Breath();
                        planet.Items.Remove(planetItem);
                    }
                }
                
            }

            

            //•	The astronauts start going out in open space one by one.They can't go, if they don't have any oxygen left.
            //    •	An astronaut lands on a planet and starts collecting its items one by one. 
            //    •	He finds an item and he takes a breath.
            //    •	He adds the item to his backpack and respectively the item must be removed from the planet.
            //    •	Astronauts can't keep collecting items if their oxygen becomes 0.
            //    •	If it becomes 0, the next astronaut starts exploring.

        }
    }
}