using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HP = 200;
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, INITIAL_HP)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;

                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = false;

                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string aggresiveOutput = this.AggressiveMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggresiveOutput}";
        }
    }
}