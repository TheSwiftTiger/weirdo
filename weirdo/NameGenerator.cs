using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    public static class NameGenerator
    {
        static StreamReader sr = new StreamReader(@"town1.txt");
        static StreamReader sr2 = new StreamReader(@"town2.txt");
        static string[] srArray1 = sr.ReadLine().Split(',');
        static string[] srArray2 = sr2.ReadLine().Split(',');

        public static string TownNameGenerator()
        {
            string _name;
            _name = srArray1[RandomNumberGenerator.RandomInt(0, srArray1.Length - 1)] + srArray2[RandomNumberGenerator.RandomInt(0, srArray2.Length - 1)];
            return _name;
        }

    }
}
