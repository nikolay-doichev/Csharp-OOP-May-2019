namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        public const double InitialOxygenLevel = 50.0;

        public Geodesist(string name)
            : base(name, InitialOxygenLevel)
        {

        }
    }
}