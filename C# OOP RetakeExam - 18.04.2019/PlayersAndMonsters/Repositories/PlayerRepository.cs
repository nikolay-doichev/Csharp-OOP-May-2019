using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> playerByName;

        public PlayerRepository()
        {
            this.playerByName = new Dictionary<string, IPlayer>();
        }
        public int Count => this.playerByName.Count;
        public IReadOnlyCollection<IPlayer> Players => this.playerByName.Values.ToList();
        public void Add(IPlayer player)
        {
            ThrowIfPlayerIsNull(player, ExceptionMessages.PlayerCannotBeNull);

            if (this.playerByName.ContainsKey(player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlreadyExist,player.Username));
            }

            this.playerByName.Add(player.Username, player);
        }
        public bool Remove(IPlayer player)
        {
            ThrowIfPlayerIsNull(player, ExceptionMessages.PlayerCannotBeNull);

            bool hasRemoved = this.playerByName.Remove(player.Username);

            return hasRemoved;
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;
            if (this.playerByName.ContainsKey(username))
            {
                player = this.playerByName[username];
            }

            return player;
        }

        private static void ThrowIfPlayerIsNull(IPlayer player, string message)
        {
            if (player == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}