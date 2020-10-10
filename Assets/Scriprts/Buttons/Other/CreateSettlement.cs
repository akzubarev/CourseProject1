using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

public class CreateSettlement : MonoBehaviour
{

    public void Settle()
    {
        int num = TileInfo.numshown;
        int numofsettlers = GameController.tile[num].Travellers;
        GameController.tile[num].Travellers = 0;

        
        string cityname = GameController.tile[num].Type + " Camp";
        Settlement city = GameController.tile[num].City = new Settlement(
            cityname, numofsettlers);
        city.Buildings = new Building(numofsettlers / 10 + 1, 0, 0, 0);
        TileInfo.ShowInfo(num);
        GameController.UpdateInfo();

    }
}
