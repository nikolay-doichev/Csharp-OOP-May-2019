using System;
using System.Collections.Generic;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut :IAstronaut
    {
        private string name;
        private double oxygen;
        private Backpack bag;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;

            this.bag = new Backpack();
        }

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
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                this.oxygen = value;
            }
        }

        //TODO: Check the calculated property
        public bool CanBreath
            => this.Oxygen > 0;

        public IBag Bag => this.bag;
        public virtual void Breath()
        {
            this.Oxygen -= 10;
            if (this.Oxygen<0)
            {
                Oxygen = 0;
            }

        }

        //•	Bag – IBag
        //    o   A property of type Backpack

    }
}