using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private ICollection<string> bags;

        public Backpack()
        {
            this.bags = new List<string>();
        }

        public ICollection<string> Items => this.bags;
    }
}