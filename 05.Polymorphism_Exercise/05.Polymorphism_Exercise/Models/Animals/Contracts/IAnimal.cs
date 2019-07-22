using System;
using System.Collections.Generic;
using System.Text;

namespace _05.Polymorphism_Exercise.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string AskFood();

        void Feed(IFood food);
    }
}
