using System;
//using System.Runtime.dll;
using System.Collections.Generic;
using System.Linq;
using MrsDoubtfiresDriveByFruitingClassLibrary.Models;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using static System.Collections.Specialized.BitVector32;
using System.Threading;
using System.Diagnostics;
//using System.Windows.Input;

namespace MrsDoubtfiresDriveByFruitingClassLibrary.Classes
{
    public static class PlayerMessages
    {
        public static void GameIntro()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to Mrs. Doubtfire's Drive By Fruiting Game: The game where you get to throw fruit at your opponent's friends!");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("The first player to fruit all five of their opponent's friends wins.");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("~Ó ~Ó !!! ~Ó ~Ó ~Ó ~Ó !!! ~Ó ~Ó");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("~Ó ~Ó !!! ~Ó ~Ó ~Ó ~Ó !!! ~Ó ~Ó");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("~Ó ~Ó !!! ~Ó ~Ó ~Ó ~Ó !!! ~Ó ~Ó");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        public static void WelcomePlayer(string name, int number)
        {
            Console.WriteLine($"Welcome, {name} (Player {number})!");
        }

        public static void ShowGridMap()
        {
            Console.WriteLine("Here is a map of the grid - each player gets their own grid.  When it's your turn to throw a fruit, you'll indicate which section of the grid you want to " +
                "throw it at by typing it's code, based on this map.");
            Console.WriteLine("  ___    ___    ___    ___    ___");
            Console.WriteLine("| _A1_ || _A2_ || _A3_ || _A4_ || _A5_|");
            Console.WriteLine("| _B1_ || _B2_ || _B3_ || _B4_ || _B5_|");
            Console.WriteLine("| _C1_ || _C2_ || _C3_ || _C4_ || _C5_|");
            Console.WriteLine("| _D1_ || _D2_ || _D3_ || _D4_ || _D5_|");
            Console.WriteLine("| _E1_ || _E2_ || _E3_ || _E4_ || _E5_|");
        }

        public static void AskForFriendPlacements()
        {
            Console.WriteLine("Please choose 5 sections on this grid where your 5 friends will be placed.  ");
               
        }

     

        public static string ChooseFriend(int friend)
        {
            Console.WriteLine($"Friend #{friend} will be placed at: ");
            return Console.ReadLine();
        }

        public static string newLine;
        public static void ShowFriendPlacementsOnGridMap(List<string> list) 
        {
            Console.WriteLine("Here are where your friends are placed on your grid, with *F indicating your friend placements.");
            
            foreach (string line in GridModel.gridLines)
            {
                foreach (string friend in list)
                {
                    if (line.Contains(friend))
                    {

                        newLine = line.Replace(friend, "*F");
                        Console.WriteLine(newLine);

                    }

                }
            }    
        }

        public static void ShowFriendPlacementsOnGridDuringVolley(List<PlayerFriendPlacement> list)
        {

            Console.WriteLine("Here is your grid: ");
            Console.WriteLine(" -- *F indicates your friend placements;");
            Console.WriteLine(" -- The ~O symbol indicates your friend was successfully fruited.  Dang!");
            Console.WriteLine(" -- An x means the computer threw a fruit at that section of your grid, but none of your friends were placed in that section; whew.");

            for (int j = 0; j <= 4; j++)
            {                 
                string value = DetermineIfFruited(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[0]);      
                Console.Write($"| {value} |");
            }
             
            Console.WriteLine("");
            for (int j = 5; j <= 9; j++)
            {
                string value = DetermineIfFruited(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[1]);
                Console.Write($"| {value} |");
            }
         
            Console.WriteLine("");
            for (int j = 10; j <= 14; j++)
            {
                string value = DetermineIfFruited(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[2]);
                Console.Write($"| {value} |");
            }
          
            Console.WriteLine("");
            for (int j = 15; j <= 19; j++)
            {
                string value = DetermineIfFruited(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[3]);
                Console.Write($"| {value} |");
            }
            
            Console.WriteLine("");
            for (int j = 20; j <= 24; j++)
                {
                string value = DetermineIfFruited(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[4]);
                Console.Write($"| {value} |");

            }
        }

        public static void ShowRedactedComputerGridDuringVolley(List<PlayerFriendPlacement> list)
        {
            Console.WriteLine("Here is the computer's grid: ");
            Console.WriteLine(" -- You can't see their friend placements!");
            Console.WriteLine(" -- The ~O symbol indicates you successfully fruited their friend in that section.  Yes!!");
            Console.WriteLine(" -- An x means you threw a fruit at that section of the computer's grid, but none of their friends were placed in that section.");

            for (int j = 0; j <= 4; j++)
            {
                string value = DetermineIfFruitedMinusFriends(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[0]);
                Console.Write($"| {value} |");
            }

            Console.WriteLine("");
            for (int j = 5; j <= 9; j++)
            {
                string value = DetermineIfFruitedMinusFriends(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[1]);
                Console.Write($"| {value} |");
            }

            Console.WriteLine("");
            for (int j = 10; j <= 14; j++)
            {
                string value = DetermineIfFruitedMinusFriends(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[2]);
                Console.Write($"| {value} |");
            }

            Console.WriteLine("");
            for (int j = 15; j <= 19; j++)
            {
                string value = DetermineIfFruitedMinusFriends(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[3]);
                Console.Write($"| {value} |");
            }

            Console.WriteLine("");
            for (int j = 20; j <= 24; j++)
            {
                string value = DetermineIfFruitedMinusFriends(list[j].friend, list[j].fruited, list[j].gridcode, GridModel.gridLines[4]);
                Console.Write($"| {value} |");

            }
        }

        public static void ThrowFruit()
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("IT'S A DRIVE BY FRUITING!!!");
            Console.WriteLine("Please stand by...");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Fruiting in progress...");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        public static string DetermineIfFruited(bool friend, bool fruited, string code, string line)
        {
            if (friend && fruited)
            {
                return "_~O_";
            }
            else if (friend && !fruited)
            {
                return "_*F_";
            }
            else if (!friend && fruited)
            {
                return "__x_";
            }
            else
            {
                return $"_{code}_";
            }
            
        }

        public static string DetermineIfFruitedMinusFriends(bool friend, bool fruited, string code, string line)
        {
            if (friend && fruited)
            {
                return "_~O_";
            }
            //else if (friend && !fruited)
            //{
                //return "_*F_";
            //}
            else if (!friend && fruited)
            {
                return "__x_";
            }
            else
            {
                return $"_{code}_";
            }

        }

        public static void ContinueGame()
        {
            Console.WriteLine("Please type 'go' to continue.");
            bool goEntered = false;
            while (!goEntered)
            {
                if (Console.ReadLine() == "go")
                {
                    goEntered = true;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please type 'go' to continue."); 
                } 
                    
            }
        }

        public static void ViewMyGrid(List<string> list)
        {
            Console.WriteLine("Type 'grid' to view your grid, or press any key and then 'enter' to continue.");
            bool gridEntered = false;
            while (!gridEntered)
            {
                if (Console.ReadLine() == "grid")
                {
                    gridEntered = true;
                    ShowFriendPlacementsOnGridMap(list);
                    Console.WriteLine("Press any key, and then 'enter', to continue.");
                    string anyKey = Console.ReadLine();
                      if (anyKey != null | anyKey != "")
                        {
                            Console.Clear();
                        } 
                } else
                {
                    gridEntered = true;
                    Console.Clear();
                }

            }
        }

        public static void StartFruitingMessage()
        {
            Console.WriteLine("Let the fruiting begin!!");
        }

        public static bool CheckIfComputerWon(List<PlayerFriendPlacement> humanList)
        {
            int count = 0;
            foreach(PlayerFriendPlacement obj in humanList)
            {
                if (obj.friend && obj.fruited)
                {
                    count++;
                }
            }
            if (count == 5)
            {

                return true;
            }
            return  false;
        }

        public static bool CheckIfHumanWon(List<PlayerFriendPlacement> computerList)
        {
            int count = 0;
            foreach (PlayerFriendPlacement obj in computerList)
            {
                if (obj.friend && obj.fruited)
                {
                    count++;
                }
            }
            if (count == 5)
            {

                return true;
            }
            return false;
        }

        public static void SuccessfullyFruitedFriend()
        {
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Successful Fruiting!  Mrs. Doubtfire would be proud!");
            Console.WriteLine("Please stand by...");
            System.Threading.Thread.Sleep(4000);
            Console.Clear();
        }

        public static void UnsuccessfulFruiting()
        {
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Darn, what a waste of a good fruit! Try to throw harder next time.");
            Console.WriteLine("Please stand by...");
            System.Threading.Thread.Sleep(4000);
            Console.Clear();
        }

        public static void TheComputerWon()
        {
            Console.WriteLine("The Computer has won!  Better luck fruiting next time!");
        }

        public static void YouWon(string playername)
        {
            Console.WriteLine($"{playername}, you won!  Way to aim with those bananas, kiwis, and oranges!");
        }

        public static bool PlayAgain()
        {
            Console.WriteLine("Would you like to play Mrs.Doubtfire's Drive By Fruiting Game again?");
            Console.WriteLine("Y or N: ");
            string response = Console.ReadLine().ToUpper();
            if(response == "Y")
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("LET THE FRUITING BEGIN AGAIN!!!");
                System.Threading.Thread.Sleep(2000);
                return true;
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Thanks for fruiting! We hope you fruit again soon!");
                System.Threading.Thread.Sleep(2000);
                return false;
            }
        }
    }
}
