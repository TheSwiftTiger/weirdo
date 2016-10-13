using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    

    public class Player
    {
        public List<Stat> PlayerStats { get; set; }
        const int STAT_COUNT = 10;

        public int CheckForStatAmount(int category)
        {
            int _counter = 0;
            foreach(var s in PlayerStats)
            {
                if(s.Category == category)
                {
                    _counter++;
                }
            }
            return _counter;
        }

        public void LevelUp()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Program.PrintSlow("%LEVEL UP!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            foreach (var v in PlayerStats)
            {
                Console.WriteLine("");
                Program.PrintSlow(v.Name + " increased by " + RandomNumberGenerator.RandomInt(1,5));
            }
        }

        public Player()
        {
            PlayerStats = new List<Stat>();

            int _doubleStat = RandomNumberGenerator.RandomInt(1, 10);
            int _zeroStat = _doubleStat;
            while (_zeroStat == _doubleStat)
            {
                _zeroStat = RandomNumberGenerator.RandomInt(1, 10);
            }
            List<int> _statsToAdd = new List<int>();
            int rng = RandomNumberGenerator.RandomInt(0, 100);

            while (_statsToAdd.Count < 10)
            {

                _statsToAdd.Clear();
                for (int i = 1; i < 11; i++)
                {
                    if (rng < 75)
                    {
                        if (i != _zeroStat)
                        {
                            if (i == _doubleStat)
                            {
                                _statsToAdd.Add(i);
                                _statsToAdd.Add(i);
                            }
                            else
                            {
                                _statsToAdd.Add(i);
                            }
                        }
                    }
                    else _statsToAdd.Add(i);
                }
            }
            _statsToAdd.Shuffle();
            
            for(int i=0;i<STAT_COUNT;i++)
            {
                PlayerStats.Add(new Stat(i,_statsToAdd[i]));
            }
        }
        
            
        
    }
}
