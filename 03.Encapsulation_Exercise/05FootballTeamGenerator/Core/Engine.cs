using System;
using System.Linq;
using System.Collections.Generic;

using _05FootballTeamGenerator.Exception;
using _05FootballTeamGenerator.Models;

namespace _05FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly List<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command
                        .Split(";")
                        .ToArray();

                    string cmdType = commandTokens[0];
                    string teamName = commandTokens[1];

                    if (cmdType == "Team")
                    {
                        Team team = new Team(teamName);
                        this.teams.Add(team);
                    }
                    else if (cmdType == "Add")
                    {
                        ValidateTeamName(teamName);
                        string playerName = commandTokens[2];
                        Stat stat = CreateStat(commandTokens);

                        Player player = new Player(playerName, stat);
                        Team team = this.teams.FirstOrDefault(t => t.Name == teamName);

                        team.AddPlayer(player);
                    }
                    else if (cmdType == "Remove")
                    {
                        ValidateTeamName(teamName);
                        string playerName = commandTokens[2];
                        Team team = this.teams.First(t => t.Name == teamName);

                        team.RemovePlayer(playerName);
                    }
                    else if (cmdType == "Rating")
                    {
                        ValidateTeamName(teamName);

                        Team team = this.teams.First(t => t.Name == teamName);
                        Console.WriteLine(team.ToString());
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                command = Console.ReadLine();
            }
        }

        private static Stat CreateStat(string[] commandTokens)
        {
            int endurance = int.Parse(commandTokens[3]);
            int sprint = int.Parse(commandTokens[4]);
            int dribble = int.Parse(commandTokens[5]);
            int passing = int.Parse(commandTokens[6]);
            int shooting = int.Parse(commandTokens[7]);

            Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
            return stat;
        }

        private void ValidateTeamName(string name)
        {
            Team team = this.teams.FirstOrDefault(t => t.Name == name);

            if (team == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MissingTeamException , name));
            }
        }
    }
}
