using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    public class StatTemplate
    {
        public int ID { get; set; }
        public List<string> StatNames { get; set; }
        public string ZeroMessage { get; set; }
        public string TwoMessage { get; set; }
        public ConsoleColor StatDisplayColor { get; set; }

        public StatTemplate(int id, ConsoleColor cc)
        {
            ID = id;
            StatDisplayColor = cc;
            StatNames = new List<string>();
        }
    }
}
