using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectsWindow : MonoBehaviour
{
    GameObject window,
        projectBeacon,
        projectArk,
        project3,
        project4,
        disclamer;

    void Awake()
    {
        projectBeacon = GameObject.Find("ProjectBeacon");
        projectArk = GameObject.Find("ProjectArk");
        project3 = GameObject.Find("Project3");
        project4 = GameObject.Find("Project4");
        disclamer = GameObject.Find("Disclamer");

        window = GameObject.Find("ProjectWindow");
        window.transform.position += new Vector3(700, 0, 0);


        window.active = false;
    }


    public void Show()
    {
        window.active ^= true;
        projectBeacon.active = GameController.turn >= 10;
        projectArk.active = GameController.beaconisbuilt != 0;
        project3.active = GameController.resources.Science > 500;
        project4.active = GameController.resources.Science > 1000;
        disclamer.active = !(projectBeacon.active || projectArk.active || project3.active || project4.active);
    }
}
