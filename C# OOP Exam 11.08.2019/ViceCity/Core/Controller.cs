using System.Collections.Generic;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller :IController
    {
        private IList<IPlayer> players;
        private IList<IGun> guns;
        public string AddPlayer(string name)
        {
            IPlayer player = players.FirstOrDefault(n => n.Name == name);
            if (player==null)
            {
                return "No player";
            }

            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            return "";
        }

        public string AddGunToPlayer(string name)
        {
            IPlayer player = players.FirstOrDefault(g => g.Name == name);
            if (guns.Count==0)
            {
                return $"There are no guns in the queue!";
            }

            if (player.Name == "Vercetti")
            {
                 
            }

            return "";
        }

        public string Fight()
        {
            throw new System.NotImplementedException();
        }
    }
}