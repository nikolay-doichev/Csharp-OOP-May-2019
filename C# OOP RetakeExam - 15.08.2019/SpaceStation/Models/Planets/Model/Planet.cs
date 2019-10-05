using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SpaceStation.Models.Planets.Model
{
    public class Planet :IPlanet
    {
        private string name;

        private ICollection<string> items;

        public Planet(string name, ICollection<string> items)
        {
            this.Name = name;
            this.items = items;
        }

        public ICollection<string> Items => this.items;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }

    }
}