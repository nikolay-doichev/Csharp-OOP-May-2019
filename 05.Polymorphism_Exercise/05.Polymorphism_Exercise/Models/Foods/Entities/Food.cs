using _05.Polymorphism_Exercise.Models.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Polymorphism_Exercise.Models.Foods.Entities
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
