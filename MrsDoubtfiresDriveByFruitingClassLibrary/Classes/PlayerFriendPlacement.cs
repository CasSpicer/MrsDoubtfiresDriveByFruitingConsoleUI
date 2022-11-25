using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrsDoubtfiresDriveByFruitingClassLibrary.Classes
{
    public class PlayerFriendPlacement
    {

        public int id;
        public string gridcode;
        public bool friend;
        public bool fruited;

        public PlayerFriendPlacement(int id, string gridcode, bool friend, bool fruited)
        {
            this.id = id;
            this.gridcode = gridcode;
            this.friend = friend;
            this.fruited = fruited;
        }

       
    }
}
