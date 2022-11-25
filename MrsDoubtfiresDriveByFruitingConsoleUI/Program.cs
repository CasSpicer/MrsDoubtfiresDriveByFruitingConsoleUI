using System;
using MrsDoubtfiresDriveByFruitingClassLibrary.Models;
using MrsDoubtfiresDriveByFruitingClassLibrary.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrsDoubtfiresDriveByFruitingClassLibrary;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace MrsDoubtfiresDriveByFruitingConsoleUI
{
    internal class Program
    {

        public const int FriendCount = 5;
        static void Main(string[] args)
        {
            bool playGame = true;
            while (playGame)
            {
                PlayerMessages.GameIntro();
                Console.WriteLine("Player 1, please enter your name: ");
                PlayerModel player1 = new PlayerModel(Console.ReadLine(), 1);

                Console.Clear();

                PlayerMessages.WelcomePlayer(player1.PlayerName, player1.PlayerNumber);
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                PlayerMessages.ShowGridMap();
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                PlayerMessages.AskForFriendPlacements();
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                for (int i = 1; i <= FriendCount; i++)
                {
                    bool isValid = false;
                    while (!isValid)
                    {
                        string friend = PlayerMessages.ChooseFriend(i).ToUpper();
                        if (player1.PlayerFriendPlacementsList.Contains(friend))
                        {
                            Console.WriteLine("Oops! You already have a friend placed in that section of the grid. Please try again.");
                        }
                        else if (PlayerModel.GridCodeList.Contains(friend))
                        {
                            isValid = true;
                            player1.PlayerFriendPlacementsList.Add(friend);
                        }
                        else
                        {
                            Console.WriteLine("Oops! Please enter only A1 - A5, B1 - B5, C1 - C5, D1 - D5 and E1 - E5. Please try again.");
                        }
                    }
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");

                PlayerMessages.ShowFriendPlacementsOnGridMap(player1.PlayerFriendPlacementsList);

                PlayerMessages.ContinueGame();

                Console.WriteLine(" ");
                Console.WriteLine(" ");

                ComputerMessages.ComputerIntroduction();
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                PlayerModel player2 = new PlayerModel("Computer", 2);


                PlayerMessages.WelcomePlayer(player2.PlayerName, player2.PlayerNumber);
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    player2.PlayerFriendPlacementsList.Add(PlayerModel.GridCodeList[rnd.Next(1, 25)]);

                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                PlayerMessages.ContinueGame();

                List<List<string>> InitialPlayerLists = new List<List<string>> { player1.PlayerFriendPlacementsList, player2.PlayerFriendPlacementsList };
                List<List<PlayerFriendPlacement>> PlayerLists = new List<List<PlayerFriendPlacement>> { player1.NewPlayerFriendPlacementsList, player2.NewPlayerFriendPlacementsList };

                for (int i = 0; i < PlayerLists.Count; i++)
                {
                    for (int j = 0; j < PlayerModel.GridCodeList.Count; j++)
                    {
                        bool isFriendThere = InitialPlayerLists[i].Contains(PlayerModel.GridCodeList[j]);
                        bool hasBeenFruited = false;
                        PlayerLists[i].Add(new PlayerFriendPlacement(j + 1, PlayerModel.GridCodeList[j], isFriendThere, hasBeenFruited));
                    }
                }

                PlayerMessages.ViewMyGrid(player1.PlayerFriendPlacementsList);

                PlayerMessages.StartFruitingMessage();
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                bool winnerExists = false;
                bool humanTookAThrow = false;



                while (!winnerExists)
                {
                    if (!humanTookAThrow)
                    { //human's turn to throw
                        PlayerScoreTracker.PlayerScoreCard(player1.PlayerName, player1.PlayerNumber, player1.NewPlayerFriendPlacementsList, player2.PlayerNumber, player2.NewPlayerFriendPlacementsList);

                        Console.WriteLine(" ");
                        Console.WriteLine(" ");

                        PlayerMessages.ShowRedactedComputerGridDuringVolley(player2.NewPlayerFriendPlacementsList);

                        Console.WriteLine(" ");
                        Console.WriteLine(" ");

                        bool fruitIsValid = false;
                        while (!fruitIsValid)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Enter the section of your opponent's grid you want to fruit (please enter only A1 - A5, B1 - B5, C1 - C5, D1 - D5 and E1 - E5): ");
                            string fruitOnGrid = Console.ReadLine().ToUpper();

                            if (PlayerModel.GridCodeList.Contains(fruitOnGrid))
                            {
                                int index = player2.NewPlayerFriendPlacementsList.FindIndex(obj => obj.gridcode.Equals(fruitOnGrid));
                                fruitIsValid = true;

                                bool notFruited = false;
                                if (!player2.NewPlayerFriendPlacementsList[index].fruited)
                                {
                                    notFruited = true;
                                    player2.NewPlayerFriendPlacementsList[index].fruited = true;
                                    PlayerMessages.ThrowFruit();
                                    if (player2.NewPlayerFriendPlacementsList[index].friend && player2.NewPlayerFriendPlacementsList[index].fruited)
                                    {
                                        PlayerMessages.SuccessfullyFruitedFriend();
                                    }
                                    else
                                    {
                                        PlayerMessages.UnsuccessfulFruiting();
                                    }
                                }
                                while (!notFruited)
                                {
                                    fruitIsValid = false;
                                    while (!fruitIsValid)
                                    {
                                        Console.WriteLine("Oops! You've already thrown fruit at this section of your opponent's grid, or you entered an incorrect value. Please enter another section (A1 - A5, B1 - B5, C1 - C5, D1 - D5 and E1 - E5): ");
                                        fruitOnGrid = Console.ReadLine().ToUpper();
                                        if (PlayerModel.GridCodeList.Contains(fruitOnGrid))
                                        {
                                            index = player2.NewPlayerFriendPlacementsList.FindIndex(obj => obj.gridcode.Equals(fruitOnGrid));
                                            fruitIsValid = true;
                                            if (!player2.NewPlayerFriendPlacementsList[index].fruited)
                                            {
                                                notFruited = true;
                                                player2.NewPlayerFriendPlacementsList[index].fruited = true;
                                                PlayerMessages.ThrowFruit();
                                                if (player2.NewPlayerFriendPlacementsList[index].friend && player2.NewPlayerFriendPlacementsList[index].fruited)
                                                {
                                                    PlayerMessages.SuccessfullyFruitedFriend();
                                                }
                                                else
                                                {
                                                    PlayerMessages.UnsuccessfulFruiting();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Oops! Please enter only A1 - A5, B1 - B5, C1 - C5, D1 - D5 and E1 - E5. Please try again.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Oops! Please enter only A1 - A5, B1 - B5, C1 - C5, D1 - D5 and E1 - E5. Please try again.");
                            }
                        }

                        humanTookAThrow = true;

                        if (PlayerMessages.CheckIfComputerWon(player1.NewPlayerFriendPlacementsList))
                        {
                            winnerExists = true;
                            Console.Clear();
                            PlayerMessages.TheComputerWon();
                        }
                        else if (PlayerMessages.CheckIfHumanWon(player2.NewPlayerFriendPlacementsList))
                        {
                            winnerExists = true;
                            Console.Clear();
                            PlayerMessages.YouWon(player1.PlayerName);
                        }

                    }
                    else //computer's turn to throw
                    {
                        PlayerScoreTracker.PlayerScoreCard(player1.PlayerName, player1.PlayerNumber, player1.NewPlayerFriendPlacementsList, player2.PlayerNumber, player2.NewPlayerFriendPlacementsList);

                        List<PlayerFriendPlacement> FilteredPlayerFriendPlacementsList = new List<PlayerFriendPlacement>();
                        foreach (PlayerFriendPlacement obj in player1.NewPlayerFriendPlacementsList)
                        {
                            if (obj.fruited == false)
                            {
                                FilteredPlayerFriendPlacementsList.Add(obj);
                            }
                        }

                        Random randomGridSection = new Random();
                        int randIndex = 0;
                        randIndex = randomGridSection.Next(0, FilteredPlayerFriendPlacementsList.Count);
                        string correctCode = FilteredPlayerFriendPlacementsList[randIndex].gridcode;
                        int correctedIndex = PlayerModel.GridCodeList.IndexOf(correctCode);

                        player1.NewPlayerFriendPlacementsList[correctedIndex].fruited = true;
                        ComputerMessages.ComputerThrowFruit(player1.NewPlayerFriendPlacementsList[correctedIndex].gridcode);

                        humanTookAThrow = false;

                        if (player1.NewPlayerFriendPlacementsList[correctedIndex].friend && player1.NewPlayerFriendPlacementsList[correctedIndex].fruited)
                        {
                            PlayerMessages.SuccessfullyFruitedFriend();
                        }
                        else
                        {
                            PlayerMessages.UnsuccessfulFruiting();
                        }

                        PlayerMessages.ShowFriendPlacementsOnGridDuringVolley(player1.NewPlayerFriendPlacementsList);
                        
                        if (PlayerMessages.CheckIfComputerWon(player1.NewPlayerFriendPlacementsList))
                        {
                            winnerExists = true;
                            Console.Clear();
                            PlayerMessages.TheComputerWon();
                        }
                        else if (PlayerMessages.CheckIfHumanWon(player2.NewPlayerFriendPlacementsList))
                        {
                            winnerExists = true;
                            Console.Clear();
                            PlayerMessages.YouWon(player1.PlayerName);
                        }

                    }

                }


                playGame = PlayerMessages.PlayAgain();
            }
            

            Console.ReadLine();
        }
    }
}
