using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{


    [Serializable]
    public class Province
    {
        public Province(int num, string name, string type)
        {
            Num = num;
            Name = name;
            Type = type;
            ProvinceProduction = SetProduction(type);
            travellers = 0;
        }

        private Production SetProduction(string type)
        {
            switch (type)
            {
                case "Forest": return new Production(2, 0, 0, 0, 0);
                case "Mountains": return new Production(0, 2, 0, 1, 0);
                case "Badlands": return new Production(0, 0, 0, 0, 0);
                case "Planes": return new Production(2, 0, 2, 0, 0);
                case "Lake": return new Production(0, 0, 2, 0, 0);
                case "Highlands": return new Production(2, 2, 0, 0, 0);
                case "Coast": return new Production(0, 0, 0, 0, 0);
                case "Swamp": return new Production(0, 0, 1, 2, 0);
                default: return new Production();

            }
        }

        public int Num;

        public string Name;

        public string Type;

        public Production ProvinceProduction;

        public Settlement City;


        public delegate void Discovery(int a);
        public Discovery discovery;

        int travellers;
        public int Travellers
        {
            get { return travellers; }
            set
            {
                bool disc = false;
                disc = travellers == 0 && Num != 2 && Num != 4;
                travellers = value;
                if (disc && travellers != 0) discovery(Num);
            }
        }

    }

}
