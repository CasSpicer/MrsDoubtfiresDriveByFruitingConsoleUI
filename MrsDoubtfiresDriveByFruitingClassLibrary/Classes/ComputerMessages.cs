using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrsDoubtfiresDriveByFruitingClassLibrary.Classes
{
    public static class ComputerMessages
    {

        public static void ComputerIntroduction()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("HELLO, I AM THE COMPUTER. I WILL NOW PLACE MY FRIENDS ON MY SECRET GRID.");
        }

        public static void ComputerThrowFruit(string code)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Please stand by...");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("THIS IS THE COMPUTER.  I WILL NOW THROW A FRUIT.");
            Console.WriteLine("Processing...");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("IT'S A DRIVE BY FRUITING!!!");
            Console.WriteLine("Processing...");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó ~Ó");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Fruiting in progress...");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"Computer throwing fruit at section : {code}");
            Console.WriteLine("Processing...");
        }
    }
}
