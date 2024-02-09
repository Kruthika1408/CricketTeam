using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase1
{
    public interface ITeamPlayer
    {
        void AddPlayer(CricketPlayer player);
        void RemovePlayer(int playerId);
        CricketPlayer GetPlayerById(int playerId);
        CricketPlayer GetPlayerByName(string playerName);
        List<CricketPlayer> GetAllPlayers();
    }

    public class CricketPlayer
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Team : ITeamPlayer
    {
        private List<CricketPlayer> players = new List<CricketPlayer>();

        public void AddPlayer(CricketPlayer player)
        {
            if (players.Count < 11)
            {
                players.Add(player);
                Console.WriteLine($"Player {player.Name} has been added to the Team List successfully.");
            }
            else
            {
                Console.WriteLine("Cannot add more than 11 players to the Team List.");
            }
        }

        public void RemovePlayer(int playerId)
        {
            CricketPlayer playerToRemove = players.FirstOrDefault(p => p.PlayerId == playerId);
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                Console.WriteLine($"Player {playerToRemove.Name} has been removed from the Team List successfully.");
            }
            else
            {
                Console.WriteLine($"Player with ID {playerId} not found in the Team List.");
            }
        }

        public CricketPlayer GetPlayerById(int playerId)
        {
            return players.FirstOrDefault(p => p.PlayerId == playerId);
        }

        public CricketPlayer GetPlayerByName(string playerName)
        {
            return players.FirstOrDefault(p => p.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
        }

        public List<CricketPlayer> GetAllPlayers()
        {
            return players;
        }
        
    }
}
