namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        public const double InitialOxygenLevel = 70.0;
        public Biologist(string name) 
            : base(name, InitialOxygenLevel)
        {

        }

        public override void Breath()
        {
            this.Oxygen -= 5;
            if (this.Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}