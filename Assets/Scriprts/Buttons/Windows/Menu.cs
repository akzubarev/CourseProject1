using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    GameObject window;

    void Awake()
    {
        window = GameObject.Find("Menu");
        window.transform.position += new Vector3(0, -800, 0);
        window.active = false;
    }

    public void Show()
    {
        window.active ^= true;
    }
}
