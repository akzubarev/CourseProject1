using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   static GameObject window;

    void Awake()
    {
        window = GameObject.Find("Main Menu");
        window.transform.position += new Vector3(0, 900, 0);
    }

    public void Show()
    {
        window.active ^= true;
    }

    public static void BackToMainMenu()
    {
        window.active ^= true;
    }

}
