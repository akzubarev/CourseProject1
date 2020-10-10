using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public static bool visible;

    GameObject window;

    void Awake()
    {
        Decision.image = GameObject.Find("Event/Image");
        Decision.textUI = GameObject.Find("Event/Description");
        Decision.nameUI = GameObject.Find("Event/Name");
        Decision.choisebutton1 = GameObject.Find("Event/Option1");
        Decision.choisebutton2 = GameObject.Find("Event/Option2");
        Decision.text1UI = GameObject.Find("Option1/Text");
        Decision.text2UI = GameObject.Find("Option2/Text");

        window = GameObject.Find("EventWindow");
        window.transform.position -= new Vector3(990, 0, 0);
        window.active = false;
        visible = true;
    }

    public void Show()
    {
        if (visible)
        {
            window.active = true;
            visible = false;
        }
    }
    public void Hide()
    {
        window.active = false;
    }

    public void LeftChoice()
    {
        result1();
    }
    public void RightChoice()
    {
        result2();
    }
    public static Result result1, result2;

}
