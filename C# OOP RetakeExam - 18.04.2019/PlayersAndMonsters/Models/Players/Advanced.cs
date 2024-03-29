﻿using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced :Player, IPlayer
    {
        private const int AdvaceInitialhealth = 250;
        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, AdvaceInitialhealth)
        {

        }
    }
}