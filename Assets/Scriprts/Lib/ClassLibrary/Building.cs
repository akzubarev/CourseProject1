using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    [Serializable]
    public class Building
    {
        public Building() : this(0, 0, 0, 0) { }

        public Building(int h, int s, int m, int hh)
        {
            HousePlaces = h * 10;
            SawmillWorkPlaces = s * 5;
            MineWorkPlaces = m * 5;
            HuntHouseWorkPlaces = hh * 5;

        }

        public void Build(string name)
        {
            switch (name)
            {
                case "House":
                    HousePlaces += 10; break;
                case "HuntHouse":
                    HuntHouseWorkPlaces += 5; break;
                case "Mine":
                    MineWorkPlaces += 5; break;
                case "Sawmill":
                    SawmillWorkPlaces += 5; break;
            }
        }

        public void Work(string name)
        {
            switch (name)
            {
                case "HuntHouse":
                    {
                        WorkedHuntHouse++;
                        break;
                    }
                case "Mine":
                    {
                        WorkedMine++;
                        break;
                    }
                case "Sawmill":
                    {
                        WorkedSawmill++;
                        break;
                    }
            }
        }

        public void Retire(string name)
        {
            switch (name)
            {
                case "HuntHouse":
                    {
                        WorkedHuntHouse--;
                        break;
                    }
                case "Mine":
                    {
                        WorkedMine--;
                        break;
                    }
                case "Sawmill":
                    {
                        WorkedSawmill--;
                        break;
                    }
            }
        }

        public int Workers(string name)
        {
            switch (name)
            {
                case "HuntHouse": return WorkedHuntHouse;
                case "Mine": return WorkedMine;
                case "Sawmill": return WorkedSawmill;
                default: return 0;
            }
        }

        public int WorkPlaces(string name)
        {
            switch (name)
            {
                case "HuntHouse": return HuntHouseWorkPlaces;
                case "Mine": return MineWorkPlaces;
                case "Sawmill": return SawmillWorkPlaces;
                default: return 0;
            }
        }

        public int HousePlaces;

        public int HuntHouseWorkPlaces;

        public int MineWorkPlaces;

        public int SawmillWorkPlaces;

        public int WorkedHuntHouse;

        public int WorkedMine;

        public int WorkedSawmill;

    }
}
