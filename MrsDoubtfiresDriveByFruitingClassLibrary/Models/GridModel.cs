using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrsDoubtfiresDriveByFruitingClassLibrary.Models
{
    public class GridModel
    {
        public static string[] gridLines = {
            "| _A1_ || _A2_ || _A3_ || _A4_ || _A5_|",
            "| _B1_ || _B2_ || _B3_ || _B4_ || _B5_|",
            "| _C1_ || _C2_ || _C3_ || _C4_ || _C5_|",
            "| _D1_ || _D2_ || _D3_ || _D4_ || _D5_|",
            "| _E1_ || _E2_ || _E3_ || _E4_ || _E5_|"
            };

        public static List<string> GridMap = new List<string>(gridLines);

    }

   
}
