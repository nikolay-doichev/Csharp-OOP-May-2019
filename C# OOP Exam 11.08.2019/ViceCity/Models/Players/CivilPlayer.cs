namespace ViceCity.Models.Players
{
    public class CivilPlayer: Player
    {
        public const int InitialLifePoints = 50;
        public CivilPlayer(string name) 
            : base(name, InitialLifePoints)
        {

        }

        public override void TakeLifePoints(int points)
        {
            this.LifePoints -= points;
        }
    }
}