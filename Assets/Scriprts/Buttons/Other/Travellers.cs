using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;


public class Travellers : MonoBehaviour
{
    public static Button northplus,
                         northminus,
                         eastplus,
                         eastminus,
                         southplus,
                         southminus,
                         westplus,
                         westminus;
    public static Text
        here,
        north,
        south,
        west,
        east;
    public static int[]
        h = { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        n = { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        s = { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        w = { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        e = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int numshown = 4;
    public static Province center;

    void Awake()
    {
        here = GameObject.Find("Travellers/Here").GetComponent<Text>();
        north = GameObject.Find("Travellers/North").GetComponent<Text>();
        south = GameObject.Find("Travellers/South").GetComponent<Text>();
        west = GameObject.Find("Travellers/West").GetComponent<Text>();
        east = GameObject.Find("Travellers/East").GetComponent<Text>();

        northplus = GameObject.Find("Travellers/Up+").GetComponent<Button>();
        northminus = GameObject.Find("Travellers/Up-").GetComponent<Button>();
        eastplus = GameObject.Find("Travellers/Right+").GetComponent<Button>();
        eastminus = GameObject.Find("Travellers/Right-").GetComponent<Button>();
        southplus = GameObject.Find("Travellers/Down+").GetComponent<Button>();
        southminus = GameObject.Find("Travellers/Down-").GetComponent<Button>();
        westplus = GameObject.Find("Travellers/Left+").GetComponent<Button>();
        westminus = GameObject.Find("Travellers/Left-").GetComponent<Button>();
    }

    public void Journey(ref Text destination, ref int value, int plusminus)
    {
        value += plusminus;
        destination.text = value.ToString();
        h[numshown] -= plusminus;
        here.text = h[numshown].ToString();

        if (center.City != null)
        {
            if (plusminus == 1)
            {
                if (center.Travellers == 0)
                    center.City.People.Idle--;
                else center.Travellers--;
            }
            else
            {
                if (center.City.People.Idle < center.City.Buildings.HousePlaces)
                    center.City.People.Idle++;
                else center.Travellers++;
            }
        }
        else center.Travellers -= plusminus;
    }

    public void Travel(int index)
    {
        switch (index)
        {
            case 1://up+
                {
                    Journey(ref north, ref n[numshown], 1);
                    break;
                }
            case -1://up-
                {
                    Journey(ref north, ref n[numshown], -1);
                    break;
                }
            case 2://right+
                {
                    Journey(ref east, ref e[numshown], 1);
                    break;
                }
            case -2://rigth-
                {
                    Journey(ref east, ref e[numshown], -1);
                    break;
                }
            case 3://down+
                {
                    Journey(ref south, ref s[numshown], 1);
                    break;
                }
            case -3://down-
                {
                    Journey(ref south, ref s[numshown], -1);
                    break;
                }
            case 4://left+
                {
                    Journey(ref west, ref w[numshown], 1);
                    break;
                }
            case -4://left-
                {
                    Journey(ref west, ref w[numshown], -1);
                    break;
                }
        }
        TileInfo.ShowInfo(numshown);
        if (center.City != null)
            BuildingsInfo.Upd();
    }

    public static void Upd()
    {
        numshown = TileInfo.numshown;
        center = GameController.tile[numshown];

        string truetravellers = "";
        string falsetravellers = "";
        h[numshown] = center.Travellers;
        if (center.Travellers != 0) truetravellers = h[numshown].ToString();
        if (center.City != null)
        {
            h[numshown] += center.City.People.Idle;
            falsetravellers = System.String.Format("({0})",
                                     center.City.People.Idle);
        }

        here.text = truetravellers + falsetravellers;
        north.text = n[numshown].ToString();
        east.text = e[numshown].ToString();
        south.text = s[numshown].ToString();
        west.text = w[numshown].ToString();


        Check();

    }

    public static void Check()
    {
        if (h[numshown] == 0)
        {
            northplus.interactable = false;
            eastplus.interactable = false;
            southplus.interactable = false;
            westplus.interactable = false;
        }
        else
        {
            northplus.interactable = true;
            eastplus.interactable = true;
            southplus.interactable = true;
            westplus.interactable = true;
        }

        VisibilityCheck(ref northminus, n[numshown]);
        VisibilityCheck(ref eastminus, e[numshown]);
        VisibilityCheck(ref southminus, s[numshown]);
        VisibilityCheck(ref westminus, w[numshown]);

        if (numshown < 3) northplus.interactable = false;
        if (numshown > 5) southplus.interactable = false;
        if (numshown % 3 == 0) westplus.interactable = false;
        if (numshown % 3 == 2) eastplus.interactable = false;


    }

    public static void VisibilityCheck(ref Button button, int direction)
    {
        if (direction == 0)
        { button.interactable = false; }
        else
        { button.interactable = true; }
    }

    public static void Arrive(ref Province square, int direction)
    {
        if (square.City == null ||
                   square.City.Buildings.HousePlaces ==
                   square.City.People.All) square.Travellers += direction;
        else square.City.People.Idle += direction;
    }
    public static void Move()
    {
        for (int i = 0; i < 9; i++)
        {

            if (i > 2)
                Arrive(ref GameController.tile[i - 3], n[i]);
            if (i < 8)
                Arrive(ref GameController.tile[i + 1], e[i]);
            if (i < 6)
                Arrive(ref GameController.tile[i + 3], s[i]);
            if (i > 1)
                Arrive(ref GameController.tile[i - 1], w[i]);

            n[i] = 0; e[i] = 0;
            s[i] = 0; w[i] = 0;

        }
        Upd();
    }
}