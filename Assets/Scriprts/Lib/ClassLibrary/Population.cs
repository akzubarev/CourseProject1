using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    public delegate void Del();

    [Serializable]
    public class Population
    {
        public Population(int idle)
        {
            Idle = idle;
            Working = 0;
        }

        public int working,
                   idle;
        public Del PeopleDying = delegate () { };
        Random rnd = new Random();
        string[] retirement = { "Sawmill", "Mine", "HuntHouse" };

        public int Working { get { return working; } set { working = value; } }

        public int Idle
        {
            get { return idle; }
            set
            {
                idle = value;
                if (idle < 0)
                {
                    idle += working;
                    working = 0;
                    PeopleDying();
                }
            }
        }


        public int All { get { return Idle + Working; } }

        public int this[string indexer]
        {
            get
            {
                switch (indexer)
                {
                    case "Idle": return Idle;
                    case "Working": return Working;
                    case "All": return All;
                    default: return 0;
                }
            }
            /*
             *set
              {
                  switch (indexer)
                  {
                      case "Idle": Idle = value; break;
                      case "Worker": Working = value; break;
                      default: break;
                  }
              }
              */
        }
    }

}



