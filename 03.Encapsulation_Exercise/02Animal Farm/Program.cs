namespace AnimalFarm
{
    using System;
    using AnimalFarm.Core;
    using AnimalFarm.Exceptions;
    using AnimalFarm.Models;
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
