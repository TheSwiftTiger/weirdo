using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    public enum SubAreaTypes { Cave,Cabin,GasStation,RestStop,BorderControl,Resort,Mansion,Mall,MilitaryBase,PlayerHome,RundownHouse,DecentHouse,FamilyHouse,Church,ApartmentBuilding,
        PublicBuilding,GeneralStore,DeptStore,WeaponStore,ClothingStore,BookStore,Kiosk,LotteryStore,Gym,Bar,FastFoodRestaurant,Casino,PoliceStation,Hospital,Pharmacy,Drugstore,
        Hotel,LivingRoom,Bedroom,Kitchen,Bathroom,Basement,Attic}

    public class SubArea : Area
    {
        public Area ParentArea { get; set; }

        public SubArea(int id, int type, Area parentArea) : base(id,type)
        {
            Objects = new List<Object>();
            SubAreas = new List<SubArea>();

            ID = id;
            Type = type;

            switch(Type)
            {
                case (int)SubAreaTypes.Bedroom:
                    {
                        Name = "Bedroom";
                        break;
                    }
                case (int)SubAreaTypes.LivingRoom:
                    {
                        Name = "Living Room";
                        break;
                    }
                case (int)SubAreaTypes.Kitchen:
                    {
                        Name = "Kitchen";
                        break;
                    }
                case (int)SubAreaTypes.Bathroom:
                    {
                        Name = "Bathroom";
                        break;
                    }
                case (int)SubAreaTypes.PlayerHome:
                    {
                        Name = "Your Home";
                        SubAreas.Add(new SubArea(0, (int)SubAreaTypes.Bedroom, this));
                        SubAreas.Add(new SubArea(1, (int)SubAreaTypes.Kitchen, this));
                        SubAreas.Add(new SubArea(2, (int)SubAreaTypes.Bathroom, this));
                        break;
                    }
            }
        }
    }
}
