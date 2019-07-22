﻿using _05.Polymorphism_Exercise.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Polymorphism_Exercise.Models.Animals.Entities
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        protected override List<Type> PrefferedFoodTypes =>
            new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 1.0;

        public override string AskFood()
        {
            return "ROAR!!!";
        }
    }
}
