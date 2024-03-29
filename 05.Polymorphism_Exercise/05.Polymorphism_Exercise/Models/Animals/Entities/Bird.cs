﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Polymorphism_Exercise.Models.Animals.Entities
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get;private set; }

        public override string ToString()
        {
            return base.ToString() + 
                $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
