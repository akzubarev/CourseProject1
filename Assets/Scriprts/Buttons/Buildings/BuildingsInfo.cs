using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;

public class BuildingsInfo : MonoBehaviour
{
    public static Building corpus =
        GameController.tile[TileInfo.numshown].City.Buildings;
    public static Population crew =
        GameController.tile[TileInfo.numshown].City.People;

    public static void SetShownInfo(string name)
    {
        if (name == "House")
            GameObject.Find("Buildings/House/WorkersValue").GetComponent<Text>().text
                = crew["All"] + "/" + corpus.HousePlaces;

        else GameObject.Find(System.String.Format(
         "Buildings/{0}/WorkersValue", name)).GetComponent<Text>().text =
                  corpus.Workers(name) + "/" + corpus.WorkPlaces(name);

    }

    public static void AddBuilding(string name)
    {
        GameController.resources -= Constants.Cost(name);
        corpus.Build(name);
        GameController.UpdateInfo();
        SetShownInfo(name);
    }

    public static void AddWorker(string name)
    {
        crew.Idle--;
        crew.Working++;
        corpus.Work(name);
        GameController.income += Constants.Output(name);
        GameController.UpdateInfo();
        SetShownInfo(name);
    }

    public static void RemoveWorker(string name)
    {
        crew.Idle++;
        crew.Working--;
        corpus.Retire(name);
        GameController.income -= Constants.Output(name);
        GameController.UpdateInfo();
        SetShownInfo(name);
    }

    public static void Upd()
    {
        corpus = GameController.tile[TileInfo.numshown].City.Buildings;
        crew = GameController.tile[TileInfo.numshown].City.People;

        bool[] clickablebutton = new bool[] { true, true, true, true, true, true, true, true, true, true };

        if (crew.Idle == 0)
        {
            clickablebutton[0] = false;
            clickablebutton[3] = false;
            clickablebutton[6] = false;
        }


        if (corpus.WorkedSawmill == corpus.SawmillWorkPlaces)
            clickablebutton[0] = false;
        if (corpus.WorkedMine == corpus.MineWorkPlaces)
            clickablebutton[3] = false;
        if (corpus.WorkedHuntHouse == corpus.HuntHouseWorkPlaces)
            clickablebutton[6] = false;

        if (corpus.WorkedSawmill == 0)
            clickablebutton[1] = false;

        if (corpus.WorkedMine == 0)
            clickablebutton[4] = false;

        if (corpus.WorkedHuntHouse == 0)
            clickablebutton[7] = false;

        if (!(GameController.resources > Constants.Cost("Sawmill")))
            clickablebutton[2] = false;

        if (!(GameController.resources > Constants.Cost("Mine")))
            clickablebutton[5] = false;

        if (!(GameController.resources > Constants.Cost("HuntHouse")))
            clickablebutton[8] = false;

        if (!(GameController.resources > Constants.Cost("House")))
            clickablebutton[9] = false;


        GameObject.Find("Sawmill/AddWorker").GetComponent<Button>().interactable = clickablebutton[0];       //0
        GameObject.Find("Sawmill/RemoveWorker").GetComponent<Button>().interactable = clickablebutton[1];    //1
        GameObject.Find("Sawmill/AddBuilding").GetComponent<Button>().interactable = clickablebutton[2];     //2
        GameObject.Find("Mine/AddWorker").GetComponent<Button>().interactable = clickablebutton[3];          //3
        GameObject.Find("Mine/RemoveWorker").GetComponent<Button>().interactable = clickablebutton[4];       //4
        GameObject.Find("Mine/AddBuilding").GetComponent<Button>().interactable = clickablebutton[5];        //5
        GameObject.Find("HuntHouse/AddWorker").GetComponent<Button>().interactable = clickablebutton[6];     //6
        GameObject.Find("HuntHouse/RemoveWorker").GetComponent<Button>().interactable = clickablebutton[7];  //7
        GameObject.Find("HuntHouse/AddBuilding").GetComponent<Button>().interactable = clickablebutton[8];   //8
        GameObject.Find("House/AddBuilding").GetComponent<Button>().interactable = clickablebutton[9];       //9

        SetShownInfo("House");
        SetShownInfo("Sawmill");
        SetShownInfo("Mine");
        SetShownInfo("HuntHouse");

        Travellers.Upd();
    }


}