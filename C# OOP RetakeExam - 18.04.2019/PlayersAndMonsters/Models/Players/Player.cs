using System;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        

        protected Player(ICardRepository cardRepository, string username, int health )
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidUsenameNullOrEmpty);
                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
               Validator.ThrowIfIntegerIsbelowZero(value,ExceptionMessages.InvalidHealthLessThanZero);
                
               this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;
        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsbelowZero(damagePoints,ExceptionMessages.InvalidDamagePointsBelowZero);

            int newHealth = this.Health - damagePoints;

            if (newHealth < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health = newHealth;
            }

        }

        public override string ToString()
        {
            return  String.Format(
                ConstantMessages.PlayerReportInfo, 
                this.Username, 
                this.Health, 
                this.CardRepository.Count);
        }
    }
}