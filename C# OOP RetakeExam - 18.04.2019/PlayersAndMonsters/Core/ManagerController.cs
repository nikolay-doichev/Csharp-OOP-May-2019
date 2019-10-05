﻿using System.Text;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;

    public class ManagerController : IManagerController
    {
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IBattleField battleField;
        public ManagerController(IPlayerFactory playerFactory, 
                                 IPlayerRepository playerRepository, 
                                 ICardFactory cardFactory,
                                 ICardRepository cardRepository,
                                 IBattleField battleField)
        {
            this.playerFactory = playerFactory;
            this.playerRepository = playerRepository;
            this.cardFactory = cardFactory;
            this.cardRepository = cardRepository;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedCard,type,name);
            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);
            string result = String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards,cardName,username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.playerRepository.Find(attackUser);
            IPlayer enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackPlayer,enemyPlayer);
            string result = String.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
            return result;
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();

           foreach (var player in this.playerRepository.Players)
           {
               sb.AppendLine(player.ToString());

               foreach (var card in player.CardRepository.Cards)
               {
                   sb.AppendLine(card.ToString());
               }

               sb.AppendLine(ConstantMessages.DefaultReportSeparator);
           }

           return sb.ToString().TrimEnd();
        }
    }
}
