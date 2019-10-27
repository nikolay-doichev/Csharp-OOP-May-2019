using System;
using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly IList<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>) this.guns;

        public void Add(IGun model)
        {
            if (guns.Contains(model))
            {
                
            }

            this.guns.Add(model);
        }

        public bool Remove(IGun model)
        {
            return guns.Remove(model);
        }

        public IGun Find(string name)
        {
            IGun searchedGun = this.guns.FirstOrDefault(g => g.Name == name);

            return searchedGun;
        }
    }
}