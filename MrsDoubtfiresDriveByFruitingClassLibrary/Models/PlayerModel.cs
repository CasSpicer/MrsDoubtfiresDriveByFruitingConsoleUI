using MrsDoubtfiresDriveByFruitingClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrsDoubtfiresDriveByFruitingClassLibrary
{
    public class PlayerModel
    {

        public int PlayerNumber { get; set; }
        public string PlayerName { get; set; }
        public int NumOfThrows { get; set; } = 0;
        public bool IsWinner { get; set; } = false;

        public int PlayerScore { get; set; } = 0;

        public static List<string> GridCodeList = new List<string> {
            "A1",
            "A2",
            "A3",
            "A4",
            "A5",
            "B1",
            "B2",
            "B3",
            "B4",
            "B5",
            "C1",
            "C2",
            "C3",
            "C4",
            "C5",
            "D1",
            "D2",
            "D3",
            "D4",
            "D5",
            "E1",
            "E2",
            "E3",
            "E4",
            "E5"
        };

        public List<string> PlayerFriendPlacementsList { get; private set; } = new List<string>();

        public List<PlayerFriendPlacement> NewPlayerFriendPlacementsList { get; private set; } = new List<PlayerFriendPlacement>();

       /* public List<PlayerFriendPlacement> TestPlayerFriendPlacementsList = new List<PlayerFriendPlacement>()
        {
            new PlayerFriendPlacement( 1, "A1",  true,  true ),
            new PlayerFriendPlacement( 2, "A2", true, true ),
            new PlayerFriendPlacement( 3, "A3",  false, false ),
            new PlayerFriendPlacement( 4, "A4",  true, true ),
            new PlayerFriendPlacement( 5, "A5",  false,  false ),
            new PlayerFriendPlacement( 6,  "B1",  true,  true ),
            new PlayerFriendPlacement( 7,  "B2",  false,  true ),
            new PlayerFriendPlacement( 8,  "B3",  false,  false ),
            new PlayerFriendPlacement( 9,  "B4",  false,  false ),
            new PlayerFriendPlacement( 10,  "B5",  false,  false ),
            new PlayerFriendPlacement( 11,  "C1",  true,  true ),
            new PlayerFriendPlacement( 12,  "C2",  false,  false ),
            new PlayerFriendPlacement( 13,  "C3",  false,  false ),
            new PlayerFriendPlacement( 14,  "C4",  false,  false ),
            new PlayerFriendPlacement( 15,  "C5",  false,  false ),
            new PlayerFriendPlacement( 16,  "D1",  false,  false ),
            new PlayerFriendPlacement( 17,  "D2",  false,  false ),
            new PlayerFriendPlacement( 18,  "D3",  false,  false ),
            new PlayerFriendPlacement( 19,  "D4",  false,  false ),
            new PlayerFriendPlacement( 20,  "D5",  false,  false ),
            new PlayerFriendPlacement( 21,  "E1",  false,  false ),
            new PlayerFriendPlacement( 22,  "E2",  false,  false ),
            new PlayerFriendPlacement( 23,  "E3",  false,  false ),
            new PlayerFriendPlacement( 24,  "E4",  false,  false ),
            new PlayerFriendPlacement( 25,  "E5",  false,  false ),
        };
       *****used for testing!****
*/
        public PlayerModel(string playerName, int playerNumber)
        {
            PlayerName = playerName;
            PlayerNumber = playerNumber;    
        }

        

    }
}
