using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrsDoubtfiresDriveByFruitingClassLibrary.Classes
{
    public static class PlayerScoreTracker
    {
      public static void PlayerScoreCard(string humanName, int humanNumber, List<PlayerFriendPlacement> humanList, int computerNumber, List<PlayerFriendPlacement> computerList)
        {
            int humanScore = 0;
            int computerScore = 0;
            foreach (PlayerFriendPlacement obj in humanList)
            {
                if (obj.friend && obj.fruited)
                {
                    computerScore++;
                }
            }
            
            foreach (PlayerFriendPlacement obj in computerList)
            {
                if (obj.friend && obj.fruited)
                {
                    humanScore++;
                }
            }
            Console.WriteLine("");
            Console.WriteLine( $"{humanName} (Player {humanNumber})'s Score: {humanScore}");
            Console.WriteLine($"Computer (Player {computerNumber})'s Score: {computerScore}");
            
        }
    }
}
