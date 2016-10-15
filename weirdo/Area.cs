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

        public Area(int id,int type)
        {
            Objects = new List<Object>();
            SubAreas = new List<SubArea>();

            ID = id;
            Type = type;

            switch (Type)
            {
                case (int)AreaTypes.Field:
                    {
                        Name = "Field";
                        break;
                    }
                case (int)AreaTypes.Forest:
                    {
                        Name = "Forest of " + NameGenerator.TownNameGenerator();
                        int _rng = RandomNumberGenerator.RandomInt(0, 100);
                        if (_rng < 15)
                            SubAreas.Add(new SubArea(0, (int)SubAreaTypes.Cave, this));
                        else if(_rng<30)
                            SubAreas.Add(new SubArea(1, (int)SubAreaTypes.Cabin, this));
                        break;
                    }
                case (int)AreaTypes.Town:
                    {
                        Name = NameGenerator.TownNameGenerator();
                        SubAreas.Add(new SubArea(0, (int)SubAreaTypes.PlayerHome, this));
                        SubAreas.Add(new SubArea(1, (int)SubAreaTypes.GeneralStore, this));
                        SubAreas.Add(new SubArea(2, (int)SubAreaTypes.PublicBuilding, this));
                        SubAreas.Add(new SubArea(3, (int)SubAreaTypes.Church, this));

                        for (int i = 4; i < 7; i++)
                        {
                            int _rng = RandomNumberGenerator.RandomInt(0, 100);

                            if (_rng < 20)
                                SubAreas.Add(new SubArea(i, (int)SubAreaTypes.RundownHouse, this));
                            else if (_rng < 80)
                                SubAreas.Add(new SubArea(i, (int)SubAreaTypes.DecentHouse, this));
                            else SubAreas.Add(new SubArea(i, (int)SubAreaTypes.FamilyHouse, this));
                        }
                        break;
                    }
                case (int)AreaTypes.Highway:
                    {
                        Name = "Highway";
                        if(RandomNumberGenerator.RandomInt(0,100)>74)
                        {
                            SubAreas.Add(new SubArea(0, (int)SubAreaTypes.RestStop, this));
                        }
                            break;
                    }
                case (int)AreaTypes.Road:
                    {
                        Name = "Road";
                        if (RandomNumberGenerator.RandomInt(0, 100) > 84)
                        {
                            SubAreas.Add(new SubArea(0, (int)SubAreaTypes.GasStation, this));
                        }
                        break;
                    }
                case (int)AreaTypes.SpecialBuilding:
                    {
                        Name = NameGenerator.TownNameGenerator() + " Plains";
                        int _rng = RandomNumberGenerator.RandomInt(0, 100);
                        if (_rng < 33)
                            SubAreas.Add(new SubArea(0, (int)SubAreaTypes.Mall, this));
                        else if (_rng < 66)
                            SubAreas.Add(new SubArea(1, (int)SubAreaTypes.Mansion, this));
                        else
                            SubAreas.Add(new SubArea(2, (int)SubAreaTypes.MilitaryBase, this));
                        break;
                    }
            }

        }
    }
}
