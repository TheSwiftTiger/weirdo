using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{

    public enum AreaTypes { Field,Path,Road,Highway,Town,City,Forest,Mountains,Border,Lake,SpecialBuilding}

    public class Area
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Type { get; set; }
        public List<Object> Objects { get; set; }

        public List<SubArea> SubAreas { get; set; }

        public bool Discovered { get; set; }

        public Area()
        {
        }
    }
}
