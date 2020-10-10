using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInfo : MonoBehaviour
{

    public static Text province,
                    type,
                    production,
                    settlementName,
                    settlementPeople;
    public static GameObject buildings,
                             createsettlement;
    public static int numshown;

    void Start()
    {
        province = GameObject.Find("ProvinceInfo/Province").GetComponent<Text>();
        type = GameObject.Find("ProvinceInfo/Type").GetComponent<Text>();
        production = GameObject.Find("ProvinceInfo/Production").GetComponent<Text>();
        settlementName = GameObject.Find("Settlement Info/Name").GetComponent<Text>();
        settlementPeople = GameObject.Find("Settlement Info/People").GetComponent<Text>();
        createsettlement = GameObject.Find("Create Settlement");
        createsettlement.active = false;
        buildings = GameObject.Find("Buildings");
        buildings.active = false;
        numshown = 4;
        ShowInfo(numshown);
    }

    public static void ShowInfo(int num)
    {
        province.text = "Province: " + GameController.tile[num].Name;
        type.text = "Type: " + GameController.tile[num].Type;
        production.text = "Production: " + GameController.tile[num].ProvinceProduction.ToString();
        numshown = num;

        if (GameController.tile[num].City != null)
        {
            settlementName.text = "City: " + GameController.tile[num].City.Name;
            settlementPeople.text = "People: " + GameController.tile[num].City.People["All"];
            buildings.active = true;
            createsettlement.active = false;
        }
        else
        {
            settlementName.text = "";
            settlementPeople.text = "";
            buildings.active = false;
            createsettlement.active = true;
            if (GameController.tile[num].Travellers < Constants.PeopleToSettle)
                createsettlement.GetComponent<Button>().interactable = false;
            else createsettlement.GetComponent<Button>().interactable = true;
        }

        
        GameController.UpdateInfo();
        Travellers.Upd();
    }

}