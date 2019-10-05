﻿using System;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }

            if (attackPlayer is Beginner)
            {
                this.BoostBegginerPlayer(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                this.BoostBegginerPlayer(enemyPlayer);
            }

            BoostPlayer(attackPlayer);

            BoostPlayer(enemyPlayer);

            int attackPlayerDamage = attackPlayer.CardRepository
                .Cards
                .Sum(c => c.DamagePoints);
            int enemyPlayerDamage = enemyPlayer.CardRepository
                .Cards
                .Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);
                if (enemyPlayer.IsDead)break;

                attackPlayer.TakeDamage(enemyPlayerDamage);
                if (attackPlayer.IsDead)break;
            }
        }

        private void BoostPlayer(IPlayer player)
        {
            int attackPlayerBonusHealt = player.CardRepository
                .Cards
                .Sum(c => c.HealthPoints);

            player.Health += attackPlayerBonusHealt;
        }

        private void BoostBegginerPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}