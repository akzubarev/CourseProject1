using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{

    public string name;

    public void AddBuilding()
    {
        BuildingsInfo.AddBuilding(name);
    }

    public void AddWorker()
    {
        BuildingsInfo.AddWorker(name);
    }

    public void RemoveWorker()
    {
        BuildingsInfo.RemoveWorker(name);
    }

}
