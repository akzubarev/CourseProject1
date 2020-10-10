using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectStart : MonoBehaviour
{
    static GameObject startBeacon,
           startArk,
           start3,
           start4,

           stopBeacon,
           stopArk,
           stopSawmill,
           stopMine;

    void Awake()
    {
        startBeacon = GameObject.Find("ProjectBeacon/Start");
        startArk = GameObject.Find("ProjectArk/Start");
        start3 = GameObject.Find("Project3/Start");
        start4 = GameObject.Find("Project4/Start");

        stopBeacon = GameObject.Find("ProjectBeacon/Stop");
        stopArk = GameObject.Find("ProjectArk/Stop");
        stopSawmill = GameObject.Find("Project3/Stop");
        stopMine = GameObject.Find("Project4/Stop");

        stopBeacon.GetComponent<Button>().interactable = false;
        stopArk.GetComponent<Button>().interactable = false;
        stopSawmill.GetComponent<Button>().interactable = false;
        stopMine.GetComponent<Button>().interactable = false;

        startBeacon.GetComponent<Button>().onClick.AddListener(() => StartProject(1));
        startArk.GetComponent<Button>().onClick.AddListener(() => StartProject(2));
        start3.GetComponent<Button>().onClick.AddListener(() => StartProject(3));
        start4.GetComponent<Button>().onClick.AddListener(() => StartProject(4));
    }

    public static void StartProject(int num)
    {
        startBeacon.GetComponent<Button>().interactable = false;
        startArk.GetComponent<Button>().interactable = false;
        start3.GetComponent<Button>().interactable = false;
        start4.GetComponent<Button>().interactable = false;

        switch (num)
        {
            case 1:
                {
                    GameController.currentproject = ProjectBase.Beacon;
                    if (GameController.firstdecisioneffect) DecisionBase.AttitudeChange(-2);
                    stopBeacon.GetComponent<Button>().interactable = true;
                    break;
                }
            case 2:
                {
                    GameController.currentproject = ProjectBase.Ark;
                    stopArk.GetComponent<Button>().interactable = true;
                    break;
                }
            case 3:
                {
                    GameController.currentproject = ProjectBase.AdvancedSawmill;
                    stopSawmill.GetComponent<Button>().interactable = true;
                    break;
                }
            case 4:
                {
                    GameController.currentproject = ProjectBase.AdvancedMine;
                    stopMine.GetComponent<Button>().interactable = true;
                    break;
                }
        }
        //interface.showprocess
    }

    public void StopProject()
    {
        stopBeacon.GetComponent<Button>().interactable = false;
        stopArk.GetComponent<Button>().interactable = false;
        stopSawmill.GetComponent<Button>().interactable = false;
        stopMine.GetComponent<Button>().interactable = false;

        startBeacon.GetComponent<Button>().interactable = true;
        startArk.GetComponent<Button>().interactable = true;
        start3.GetComponent<Button>().interactable = true;
        start4.GetComponent<Button>().interactable = true;

        switch (GameController.currentproject.name)
        {
            case "Beacon":
                {
                    ProjectBase.Beacon = GameController.currentproject;
                    break;
                }
            case "Ark":
                {
                    ProjectBase.Ark = GameController.currentproject;
                    break;
                }
            case "3":
                {
                    //ProjectBase.3 = GameController.currentproject;
                    break;
                }
            case "4":
                {
                    //ProjectBase.4 = GameController.currentproject;
                    break;
                }
        }
        GameController.currentproject = null;
    }

    public static void EndProject()
    {
        startBeacon.GetComponent<Button>().interactable = true;
        startArk.GetComponent<Button>().interactable = true;
        start3.GetComponent<Button>().interactable = true;
        start4.GetComponent<Button>().interactable = true;

        //interface.stopshowingprogress
    }

}
