using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITeamPlayer cricketTeam = new Team();

            int choice;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("Enter 1. To Add Player");
                Console.WriteLine("Enter 2. To Remove Player");
                Console.WriteLine("Enter 3. To Get Player by ID");
                Console.WriteLine("Enter 4. To Get Player by Name");
                Console.WriteLine("Enter 5. To Get All Players");
                Console.WriteLine("Enter 6. To Exit");

                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Player ID: ");
                            if (int.TryParse(Console.ReadLine(), out int playerId))
                            {
                                Console.Write("Enter Player Name: ");
                                string playerName = Console.ReadLine();
                                Console.Write("Enter Player Age: ");
                                if (int.TryParse(Console.ReadLine(), out int playerAge))
                                {
                                    CricketPlayer newPlayer = new CricketPlayer
                                    {
                                        PlayerId = playerId,
                                        Name = playerName,
                                        Age = playerAge
                                    };
                                    cricketTeam.AddPlayer(newPlayer);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid age Input.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid PlayerId Input.");
                            }
                            break;
                        case 2:
                            Console.Write("Enter Player ID to remove: ");
                            if (int.TryParse(Console.ReadLine(), out int playerIdToRemove))
                            {
                                cricketTeam.RemovePlayer(playerIdToRemove);
                            }
                            else
                            {
                                Console.WriteLine("Invalid player ID input.");
                            }
                            break;

                        case 3:
                            Console.Write("Enter Player ID to get details: ");
                            if (int.TryParse(Console.ReadLine(), out int playerIdToGet))
                            {
                                CricketPlayer playerById = cricketTeam.GetPlayerById(playerIdToGet);
                                if (playerById != null)
                                {
                                    Console.WriteLine($"\n PlayerId: {playerById.PlayerId}, Name: {playerById.Name}, Age: {playerById.Age}");
                                }
                                else
                                {
                                    Console.WriteLine($"Player with ID {playerIdToGet} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid player ID input.");
                            }
                            break;

                        case 4:
                            Console.Write("Enter Player Name to get details: ");
                            string playerNameToGet = Console.ReadLine();
                            CricketPlayer playerByName = cricketTeam.GetPlayerByName(playerNameToGet);
                            if (playerByName != null)
                            {
                                Console.WriteLine($"\n PlayerId: {playerByName.PlayerId}, Name: {playerByName.Name} , Age: {playerByName.Age}");
                            }
                            else
                            {
                                Console.WriteLine($"Player with Name {playerNameToGet} not found.");
                            }
                            break;

                        case 5:
                            List<CricketPlayer> allPlayers = cricketTeam.GetAllPlayers();
                            Console.WriteLine("All Players in the team:");
                            foreach (var player in allPlayers)
                            {
                                Console.WriteLine($"PlayerId: {player.PlayerId}, Name: {player.Name}, Age: {player.Age}");
                            }
                            break;

                        case 6:
                            Console.WriteLine("Exiting the program.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter the correct number.");
                }

                
              Console.WriteLine();
            } while (choice != 6);
        }
    }
}
