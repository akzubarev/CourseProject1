using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public Text turntext;

    void Awake()
    {
        turntext.text = "Turn: " + 1;
    }

    public void SetTurn()
    {
        GameController.NewTurn();
        turntext.text = "Turn: " + GameController.turn;

    }
}