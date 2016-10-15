using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    public class Object
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public bool Collectible { get; set; }

        public Area Location { get; set; }

        public void CreateIn(Area destinationArea)
        {
            destinationArea.Objects.Add(this);
            Location = destinationArea;
        }

        public void MoveTo(Area destinationArea)
        {
            Location.Objects.Remove(this);
            Location = destinationArea;
            destinationArea.Objects.Add(this);
        }
    }
}
