    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

public class Constants : MonoBehaviour
{
    public static int PeopleToSettle = 10;

    public static Production
          housecost = new Production(20, 10, 0, 0, 0),
          minecost = new Production(40, 0, 0, 0, 0),
          hunthousecost = new Production(20, 0, 0, 0, 0),
          sawmillcost = new Production(20, 0, 0, 0, 0),

          houseoutput = new Production(0, 0, 0, 1, 1),
          mineoutput = new Production(0, 1, 0, 0, 0),
          hunthouseoutput = new Production(0, 0, 4, 0, 0),
          sawmilloutput = new Production(1, 0, 0, 0, 0);

    public static Production Cost(string name)
    {
        switch (name)
        {
            case "House": return housecost;
            case "Sawmill": return sawmillcost;
            case "Mine": return minecost;
            case "HuntHouse": return hunthousecost;
            default: return new Production();
        }
    }

    public static Production Output(string name)
    {
        switch (name)
        {
            case "House": return houseoutput;
            case "Sawmill": return sawmilloutput;
            case "Mine": return mineoutput;
            case "HuntHouse": return hunthouseoutput;
            default: return new Production();
        }
    }
}
