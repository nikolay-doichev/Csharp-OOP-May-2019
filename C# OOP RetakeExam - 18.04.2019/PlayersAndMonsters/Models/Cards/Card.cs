using System;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card :ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.InvalidCardNameNullOrEmpty);
                name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                Validator.ThrowIfIntegerIsbelowZero(value, ExceptionMessages.InvalidCardDamagePointsBelowZero);
                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            private set
            {
                Validator.ThrowIfIntegerIsbelowZero(value,ExceptionMessages.InvalidCardHealthLessThanZero);
                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return String.Format(
                ConstantMessages.CardReportInfo,
                this.Name,
                this.DamagePoints);
        }
    }
}