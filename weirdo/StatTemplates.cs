using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    enum StatTypes { Bonus, Dexterity, Endurance, Faith, Handiness, Intelligence, Luck, Mischief, Perception, Social, Strength }

    public static class StatTemplates
    {
        static StreamReader sr = new StreamReader(@"stats.txt");

        
        public static StatTemplate Bonus = new StatTemplate(0,ConsoleColor.DarkMagenta);
        public static StatTemplate Dexterity = new StatTemplate(1,ConsoleColor.Yellow);
        public static StatTemplate Endurance = new StatTemplate(2,ConsoleColor.Red);
        public static StatTemplate Faith = new StatTemplate(3,ConsoleColor.White);
        public static StatTemplate Handiness = new StatTemplate(4,ConsoleColor.Gray);
        public static StatTemplate Intelligence = new StatTemplate(5,ConsoleColor.Magenta);
        public static StatTemplate Luck = new StatTemplate(6,ConsoleColor.Green);
        public static StatTemplate Mischief = new StatTemplate(7,ConsoleColor.Cyan);
        public static StatTemplate Perception = new StatTemplate(8,ConsoleColor.Blue);
        public static StatTemplate Social = new StatTemplate(9,ConsoleColor.DarkGreen);
        public static StatTemplate Strength = new StatTemplate(10,ConsoleColor.DarkYellow);

        public static List<StatTemplate> StatTemplateList = new List<StatTemplate> { Bonus, Dexterity, Endurance, Faith, Handiness, Intelligence, Luck, Mischief, Perception, Social, Strength };
        
        public static StatTemplate GetStatTemplateByID(int id)
        {
            foreach(var st in StatTemplateList)
            {
                if(st.ID == id)
                {
                    return st;
                }
            }
            return null;
        }

        public static void AddStatNamesFromTextFile(StatTemplate statTemplate)
        {
            foreach (var v in sr.ReadLine().Split(','))
            {
                statTemplate.StatNames.Add(v);
            }
        }

        public static void InitializeStatTemplates()
        {
            foreach(var st in StatTemplateList)
            {
                AddStatNamesFromTextFile(st);
            }
            foreach(var st in StatTemplateList)
            {
                st.ZeroMessage = sr.ReadLine();
            }
            foreach(var st in StatTemplateList)
            {
                st.TwoMessage = sr.ReadLine();
            }
        }

    }
}
