using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>) this.planets;

        public void Add(IPlanet model)
            => this.planets.Add(model);

        public bool Remove(IPlanet model)
        {
            bool isRemoved = this.planets.Remove(model);
            return isRemoved;
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = this.planets.FirstOrDefault(p => p.Name == name);

            return planet;
        }
    }
}