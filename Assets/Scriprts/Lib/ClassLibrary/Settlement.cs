using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lib
{
    [Serializable]
    public class Settlement
    {
        public Settlement(string name, int numofsettlers)
        {
            Name = name;
            People = new Population(numofsettlers);
            Buildings = new Building(0, 0, 0, 0);
        }

        public string Name;

        public Building Buildings;

        public Production Product
        {
            get
            {
                return new Production(Buildings.WorkedSawmill,
                                      Buildings.WorkedMine, 
                                      Buildings.WorkedHuntHouse*4, 
                                      People.All,
                                      Buildings.HousePlaces/10);
            }
        }

        public Population People;

        public void IncreasePopulation()
        {
            People.Idle++;
        }


    }
}
