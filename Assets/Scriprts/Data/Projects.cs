using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lib;

public class Project : MonoBehaviour
{

    public string name, price, text;
    Production costperturn;
    int turns;
    public int turnsleft;
    Decision enddecision;
    bool visible;

    public Production bonus = new Production(0, 0, 0, 0, 0);

    public Project(string name, Production costperturn, int turns, Decision enddecision)
    {
        this.name = name;
        this.costperturn = costperturn;
        this.turns = this.turnsleft = turns;
        this.enddecision = enddecision;
    }

    public void Contribute()
    {
        if (turnsleft < 1) Debug.Log("Project already completed");
        else
        {
            if (GameController.resources > costperturn)
            {
                turnsleft--;
                GameController.resources -= costperturn;
            }

            if (turnsleft == 0) Complete();
        }
    }

    public void Complete()
    {
        GameController.incomebonus += bonus;
        GameController.currentproject = null;

        try { enddecision.Show(); }
        catch (System.NullReferenceException) { }

        ProjectStart.EndProject();
    }
}

public class ProjectBase
{
    public static Project
        Beacon = new Project("Beacon", new Production(50, 50, 0, 0, 0), 10, DecisionBase.beaconbuilt),
        Ark = new Project("The Ark", new Production(75, 75, 0, 0, 0), 20, DecisionBase.arkbuilt),
        AdvancedSawmill = new Project("AdvancedSawmill", new Production(10, 40, 0, 0, 0), 10, null) { bonus = new Production(20, 0, 0, 0, 0) },
        AdvancedMine = new Project("AdvancedMine", new Production(40, 20, 0, 0, 0), 10, null) { bonus = new Production(0, 20, 0, 0, 0) };

}