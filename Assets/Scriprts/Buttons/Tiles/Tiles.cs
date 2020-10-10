using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;
using System;

public class Tiles : MonoBehaviour
{
    public int num;

    void OnMouseDown()
    {
        TileInfo.ShowInfo(num);
    }
}