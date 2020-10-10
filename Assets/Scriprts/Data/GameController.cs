using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Lib;

public class GameController : MonoBehaviour
{
    public static Province[] tile;
    public static int turn;
    public static Production resources;
    public static Production income;


    public static Production incomebonus;

    public static bool firstdecisioneffect = false;
    public static int beaconisbuilt = 0;
    public static bool arkisbuilt = false;
    public static int attitude = 0;

    public static Project currentproject = new Project("The Ark", new Production(75, 75, 0, 0, 0), 20, DecisionBase.arkbuilt);

    public void Start()
    {
        Debug.Log("переписать прирост населения\n" +
            "закинуть Constants в Lib и все там связать\n\n");

        NewGame();
    }

    public void NewGame()
    {
        resources = new Production(20, 20, 20, 0, 0);
        income = new Production(7, 7, 20, 0, 0);
        incomebonus = new Production(0, 0, 0, 0, 0);
        turn = 1;
        GameObject.Find("Turn").GetComponent<Text>().text = "Turn: 1";
        arkisbuilt = false;
        beaconisbuilt = 0;
        attitude = 0;

        tile = new Province[9];

        for (int i = 0; i < 9; i++)
        {
            string name = "",
                   type = "";


            switch (i)
            {
                case 0: { name = "North-West"; type = "Badlands"; break; }
                case 1: { name = "North"; type = "Swamp"; break; }
                case 2: { name = "North-East"; type = "Coast"; break; }
                case 3: { name = "West"; type = "Forest"; break; }
                case 4: { name = "Center"; type = "Planes"; break; }
                case 5: { name = "East"; type = "Highlands"; break; }
                case 6: { name = "South-West"; type = "Planes"; break; }
                case 7: { name = "South"; type = "Lake"; break; }
                case 8: { name = "South-East"; type = "Mountains"; break; }
            }

            tile[i] = new Province(i, name, type);

            tile[i].discovery = delegate (int num)
            {
                string sealname = String.Format("Seal{0}", num);
                try
                {
                    GameObject.Find(sealname).active = false;
                }
                catch (NullReferenceException) { }
            };
        }

        tile[4].City = new Settlement("Hometown", 20);
        resources.Humans += 20;

        tile[4].City.Buildings = new Building(2, 1, 1, 1);

        for (int i = 0; i < 15; i++)
        {
            if (i < 5)
                tile[4].City.Buildings.Work("Sawmill");
            if (i >= 5 && i < 10)
                tile[4].City.Buildings.Work("Mine");
            if (i >= 10)
                tile[4].City.Buildings.Work("HuntHouse");
            tile[4].City.People.Working++;
            tile[4].City.People.Idle--;
        }

        //вернуть pointer на центр

        DecisionBase.start.Show();

        UpdateInfo();
    }

    public static System.Random rnd = new System.Random();

    public static void DecisionHandler()
    {
        if (resources.Humans < 1) DecisionBase.dead.Show();
        else if (turn == 10) DecisionBase.queststart.Show();
        else if (beaconisbuilt > 0) { DecisionBase.revenants.Show(); beaconisbuilt = -1; }
        else if (turn == 70) End();
        else if (rnd.Next(0, 101) < 5 && turn > 10) DecisionBase.attitudeevent.Show();
    }

    public static void End()
    {
        if (arkisbuilt)
            if (resources.Humans > 100)
                if (resources.Food > resources.Humans * 30) DecisionBase.end.Show();
                else DecisionBase.notgoodend.Show();
            else DecisionBase.notgoodend.Show();
        else DecisionBase.badend.Show();
    }

    #region Updates
    public static void NewTurn()
    {
        turn++;
        UpdatePeople();
        ResourcesAdd();
        Travellers.Move();
        DecisionHandler();
        if (currentproject == null)//WTFFFFFF
        {
            currentproject.Contribute();
        }
        UpdateInfo();
    }

    public static void NewIncome()
    {
        income = new Production();
        resources.Humans = 0;

        foreach (Province land in tile)
        {
            if (land.City != null)
            {
                income += land.City.Product + land.ProvinceProduction;
                resources.Humans += land.City.People["All"];
            }
        }
        income += incomebonus;
        income = (income * (4 + attitude)) / 4;
        income.Food -= resources.Humans;
    }

    public static void ResourcesAdd()
    {
        resources += income;
    }

    public static void UpdateInfo()
    {
        NewIncome();
        if (tile[TileInfo.numshown].City != null)
            BuildingsInfo.Upd();
        Resources.UpdateResources(resources, income);
        InPosition();
    }

    public static void UpdatePeople()
    {

        foreach (Province land in tile)
            if (land.City != null)
            {
                Population people = land.City.People;
                Building buildings = land.City.Buildings;
                people.PeopleDying = delegate
                 {
                     buildings.WorkedSawmill = 0;
                     buildings.WorkedMine = 0;
                     buildings.WorkedHuntHouse = 0;
                 };

                people.Idle += income.Food / 10 + 1;

                if (resources.Food < 0)
                    people.Idle += resources.Food;

                if (people.All <= 0)
                {
                    land.City = null;
                    TileInfo.ShowInfo(TileInfo.numshown);
                }

                if (buildings.HousePlaces < people.All)
                    land.City.People.Idle -= people.All - buildings.HousePlaces;

            }
    }

    public static void InPosition()
    {
        GameObject.Find("Pointer").transform.localPosition = new Vector3(-20, -60, -5) + new Vector3(110 * attitude, 0, 0);
        GameObject.Find("Turn").GetComponent<Text>().text = "Turn: " + turn;
    }
    #endregion

    public static void GetFromSave(Province[] _tile,
                                   int _turn,
                                   Production _resources,
                                   Production _income,
                                   Production _incomebonus,
                                   bool _firstdecisioneffect,
                                   int _beaconisbuilt,
                                   bool _arkisbuilt,
                                   int _attitude)
    {
        tile = _tile;
        turn = _turn;
        resources = _resources;
        income = _income;
        incomebonus = _incomebonus;
        firstdecisioneffect = _firstdecisioneffect;
        beaconisbuilt = _beaconisbuilt;
        arkisbuilt = _arkisbuilt;
        attitude = _attitude;

        TileInfo.ShowInfo(TileInfo.numshown);
        UpdateInfo();
    }
}
