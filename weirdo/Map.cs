using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    public class Map
    {
        public Area[,] Areas { get; set; }

        public Map()
        {
            Areas = new Area[10, 10];
            int _counter = 0;
            for (int i = 0; i < 10;i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Areas[j,i] = new Area(_counter, (int)AreaTypes.Field);
                    _counter++;
                }
            }
            int _tempID = Areas[3, 3].ID;
            Areas[3, 3] = new Area(_tempID, (int)AreaTypes.Town);
        }
    }
}
