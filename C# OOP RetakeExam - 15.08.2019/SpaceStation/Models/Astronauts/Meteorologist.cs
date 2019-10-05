namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist :Astronaut
    {
        public const double InitialOxygenLevel = 90.0;
        public Meteorologist(string name) 
            : base(name, InitialOxygenLevel)
        {

        }
    }
}