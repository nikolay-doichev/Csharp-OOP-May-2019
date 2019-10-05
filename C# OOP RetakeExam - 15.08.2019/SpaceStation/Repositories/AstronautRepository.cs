using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>) this.astronauts;

        public void Add(IAstronaut model)
            => this.astronauts.Add(model);

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut searchedAstronaut = this.astronauts.FirstOrDefault(a => a.Name == name);

            return searchedAstronaut;
        }
    }
}