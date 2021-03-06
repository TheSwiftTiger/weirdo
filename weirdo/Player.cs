﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Timers;

namespace weirdo
{
    

    public class Player : Object
    {
        public List<Stat> PlayerStats { get; set; }
        const int STAT_COUNT = 10;

        public int money = 50;

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

        public void PickupItem(int type, int amount)
        {

        }

        public void PickupMoney(int amount)
        {
            money += amount;
            Program.PrintSlow($"You found §${amount}ß.");
            DisplayMoney();
        }

        public void Buff(Stat type, int time, int strength, string name)
        {
            type.Value += strength;
            Timer buffTimer = new Timer();
            
            Program.PrintSlow($"Your §{type.Name}ß has increased for §{time}ß seconds by §{strength}ß.\n");
            buffTimer.Elapsed += (sender, e) => BuffEnd(sender, e, type, strength, name, buffTimer);
            buffTimer.Interval = time * 1000;
            buffTimer.Enabled = true;
        }

        public static void BuffEnd(object source, ElapsedEventArgs e, Stat type, int strength, string name, Timer buffTimer)
        {
            type.Value -= strength;
            Program.PrintSlow($"Your §{name}ß ran out, reducing your §{type.Name}ß.\n");
            buffTimer.Enabled = false;
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

        public void DisplayMoney()
        {
            Console.WriteLine("");
            Program.PrintSlow("You have ");
            Console.ForegroundColor = ConsoleColor.Green;
            Program.PrintSlow($"${money}");
            Console.ForegroundColor = ConsoleColor.White;
            Program.PrintSlow(".");
            Console.WriteLine("");
        }

        public void ReadBook(int wordrichness, int type)
        {
            Stat intelligence = null;
            foreach (Stat s in PlayerStats)
            {
                if (s.Category == StatTemplates.Intelligence.ID)
                {
                    intelligence = s;
                }
            }
            string[] words = File.ReadLines(@"words.txt").Skip(type).Take(1).First().Split(',');
            string[] facts = File.ReadLines(@"facts.txt").Skip(type).Take(1).First().Split(',');
            int wlearnt = RandomNumberGenerator.RandomInt(2, wordrichness);
            int flearnt = RandomNumberGenerator.RandomInt(0, facts.Count()) - 1;
            int intel = Convert.ToInt32(wlearnt * 0.8);
            if (flearnt == -1)
            {
                Program.PrintSlow($"You learnt §{wlearnt}ß new words:\n§{String.Join(", ", Program.Shuffle(words).Take(wlearnt))}ß\n\nYou learnt no facts.\n\nThis gives you §{intel} {intelligence.Name}ß!");
            }
            else
            {
                intel += 2;
                Program.PrintSlow($"You learnt §{wlearnt}ß new words:\n§{String.Join(", ", Program.Shuffle(words).Take(wlearnt))}ß\n\nYou learnt a fact: {facts[flearnt]}.\n\nThis gives you §{intel} {intelligence.Name}ß!");
            }
            intelligence.Value += intel;
        }

        public Player()
        {
            ID = 0;
            Name = "Player";
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
