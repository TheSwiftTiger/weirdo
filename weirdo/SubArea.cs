using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weirdo
{
    public enum SubAreaTypes { Cave,Cabin,GasStation,RestStop,BorderControl,Resort,Mansion,Mall,MilitaryBase,PlayerHome,RundownHouse,DecentHouse,FamilyHouse,Church,ApartmentBuilding,
        PublicBuilding,GeneralStore,DeptStore,WeaponStore,ClothingStore,BookStore,Kiosk,LotteryStore,Gym,Bar,FastFoodRestaurant,Casino,PoliceStation,Hospital,Pharmacy,Drugstore,
        Hotel,Hallway,LivingRoom,Bedroom,Kitchen,Bathroom,Basement,Attic}

    public class SubArea : Area
    {
        public Area ParentArea { get; set; }
    }
}
