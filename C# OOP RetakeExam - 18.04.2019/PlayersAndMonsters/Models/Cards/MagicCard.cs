using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card, ICard
    {
        private const int InitialDamagePoints = 5;
        private const int InitialHealthPoints = 80;
        public MagicCard(string name) 
            : base(name, InitialDamagePoints, InitialHealthPoints)
        {

        }
    }
}