namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string NameMainPlayer = "Tommy Vercetti";
        private const int InitialLifePoints = 100;
        public MainPlayer() 
            : base(NameMainPlayer, InitialLifePoints)
        {

        }

        public override void TakeLifePoints(int points)
        {
            this.LifePoints -= points;
        }
    }
}