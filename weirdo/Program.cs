using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace weirdo
{
    

    class Program
    {
      
        public static bool YesOrNo(string prompt)
        {
            
            string s = "";
            Console.WriteLine(prompt);
            while (s != "y" && s != "n")
            {
                s = Console.ReadLine();
            }
            if (s == "y")
            {
                return true;
            }
            else return false;
        }

        public static IList<T> Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomNumberGenerator.RandomInt(0, n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static void PrintSlow(string text)
        {
            foreach (var c in text)
            {
                if (c == '%')
                    Console.WriteLine("");
                else if (c == '§')
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (c == 'ß')
                    Console.ForegroundColor = ConsoleColor.White;
                else Console.Write(c);
                Thread.Sleep(RandomNumberGenerator.RandomInt(10, 100));
            }
        }
      
        static void Main(string[] args)
        {
            StatTemplates.InitializeStatTemplates();
            var player = new Player();
            var map = new Map();
            player.CreateIn(map.Areas[3, 3].SubAreas[0]);

            foreach(var s in player.PlayerStats)
            {
                Console.ForegroundColor = StatTemplates.GetStatTemplateByID(s.Category).StatDisplayColor;
                Console.WriteLine(s.Name + ": " + s.Value);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            for (int i = 1; i < 11; i++)
            {
                if (player.CheckForStatAmount(i) == 0)
                {
                    Console.WriteLine(StatTemplates.GetStatTemplateByID(i).ZeroMessage);
                    Console.WriteLine("");
                    Console.WriteLine("However...");
                    Console.WriteLine("");
                }
            }
            for (int i = 1; i < 11; i++)
            { 
                if (player.CheckForStatAmount(i)==2)
                {
                    Console.WriteLine(StatTemplates.GetStatTemplateByID(i).TwoMessage);
                }
            }
           // player.DisplayMoney();
           // player.PickupMoney(100);

            ConsoleKeyInfo _input;
            _input = Console.ReadKey(false);
            Debug.WriteLine(_input.KeyChar.ToString().ToUpper());
            if (_input.KeyChar.ToString().ToUpper() == "L")
            {
                player.LevelUp();
                
               
            }
            else if (_input.KeyChar.ToString().ToUpper() == "S")
            {
                if (player.CheckForStatAmount(StatTemplates.Intelligence.ID) != 0)
                {
                    player.ReadBook(9, 1);
                }
                else
                {
                    PrintSlow("You cannot read books.");
                }

               
            }
           else if (_input.KeyChar.ToString().ToUpper() == "G")
            {
                if (player.CheckForStatAmount(StatTemplates.Intelligence.ID) != 0)
                {
                    player.ReadBook(5, 0);
                }
                else
                {
                    PrintSlow("You cannot read books.");
                }

               
            }
            else if (_input.KeyChar.ToString().ToUpper() == "A")
            {
                Console.WriteLine("");
                PrintSlow("You are standing in §" + player.Location.Name + "ß.");
                Console.WriteLine("");
                PrintSlow("Nearby are:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach(var s in player.Location.SubAreas)
                {
                    Console.WriteLine("a " + s.Name);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.WriteLine("");
            }
            
        }
    }
}
