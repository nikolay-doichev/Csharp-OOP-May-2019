using System;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun :IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }
                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get
            {
                return this.bulletsPerBarrel;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }
                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get
            {
                return this.totalBullets;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }
                this.totalBullets = value;
            }
        }

        public bool CanFire => this.BulletsPerBarrel > 0;
        public abstract int Fire();


        //The Fire method acts different in all child classes.It shoots bullets and returns the number of bullets that were shot.Here is how it works: 
        //•	Your guns have a barrel, which have a certain capacity for bullets and you shoot a different count of bullets when you pull the trigger. 
        //•	If your barrel becomes empty, you need to reload before you can shoot again.
        //•	Reloading is done by refilling the whole barrel of the gun (Keep in mind, that every barrel has capacity).
        //•	The bullets you take for reloading are taken from the gun's total bullets stock. 
        //    Keep in mind, that every type of gun shoots different count of bullets, when you pull the trigger!

    }
}