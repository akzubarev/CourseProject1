using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;

public class Decision : MonoBehaviour
{
    string name,
           text;

    public static GameObject image,
                 textUI,
                 nameUI,
                 choisebutton1,
                 choisebutton2,
                 text1UI,
                 text2UI;

    public Choice option1, option2;

    public Decision(string _name, string _text)
    {
        name = _name;
        text = _text;
    }

    public void Show()
    {
        nameUI.GetComponent<Text>().text = name;
        textUI.GetComponent<Text>().text = text;

        text1UI.GetComponent<Text>().text = option1.text;
        text2UI.GetComponent<Text>().text = option2.text;

        Actions.result1 = option1.result;
        Actions.result2 = option2.result;
        Actions.visible = true;
    }

}

public delegate void Result();


public class Choice
{
    public string text;
    public Result result;

    public Choice(string text, Result result)
    {
        this.text = text;
        this.result = result;
    }
}


public class DecisionBase : MonoBehaviour
{
    public static Decision start = new Decision("New Beggining",
        "Everything has been quite good since we settled, but today out scientists have discovered something really important:\n" +
        "The Cataclysm is going to reach us in 70 weeks, so we really need to prepare for it")
    {
        option1 = new Choice("Tell them now (Attitude set to Panic)", () => { AttitudeChange(-2); }),
        option2 = new Choice("Wait till we have some plan (same effect after first project start)", () => { GameController.firstdecisioneffect = true; })
    };

    public static Decision queststart = new Decision("Mysterious Message",
       "Some letter was nailed to my door, no one could tell me by who\n" +
       "The note was written by the same man who directed us to this island, he wrote about his plan to save us\n" +
        "The first step is to build a beacon to guide the leftovers of humanity here, the scheme was attached")
    {
        option1 = new Choice("Start right now (50w+50i for 10 turns)",
                     () => { ProjectStart.StartProject(1); }),
        option2 = new Choice("We need some time to start working (project will appear in Projects menu)",
                    () => { }),
    };

    public static Decision beaconbuilt = new Decision("Work finished",
       "We did it. It started working, but what's next?\n" +
       "The Man sends another note, this time it's left on the door of the beacon house\n" +
        "The next step is to build a ship he calls \"ARK\" because all existing ships are dead after the EMT explosion")
    {
        option1 = new Choice("Start right now (75w75i for 20 turns)",
            () => { GameController.beaconisbuilt = 1; ProjectStart.StartProject(2); }),
        option2 = new Choice("We need some time to start working (project will appear in Projects menu)",
            () => { })
    };

    public static Decision arkbuilt = new Decision("Work finished",
       "The work took very much from us, but we finally finished it - the Ark is ready\n" +
       "All we need to do now is collect enough food so we can survive the journey, at least 3f for each pearson\n" +
        "We'll sail to the Tibet mountains, the Man said that there is a safe haven for the rest of humanity")
    {
        option1 = new Choice("We'll gather as much as we can", () => { GameController.arkisbuilt = true; }),
        option2 = new Choice("Let's do this now", GameController.End)
    };

    public static Decision revenants = new Decision("Revenants",
       "The beacon! It worked! The first fisherman on a small motorboat reached our island\n" +
       "He told us that he was not alone, and now he brought all his people here\n" +
        "I didn't really believe in that, but now is seems like we really stand a chance in surviving")
    {
        option1 = new Choice("Let's setlle them in our capital ", () => { GameController.tile[4].City.People.Idle += 20; }),
        option2 = new Choice("We don't have enough food to accept them", () => { AttitudeChange(-2); })
    };

    public static Decision end = new Decision("The End",
       "Here it is, the Man was right to the hour\n" +
       "We embarked the Ark and we should survive this ride, we were prepared for this\n" +
        "Our future starts now")
    {
        option1 = new Choice("Back to Main Menu", () => { MainMenu.BackToMainMenu(); }),
        option2 = new Choice("Close the game", () => { })//
    };

    public static Decision badend = new Decision("The End",
       "Oh God...we are not ready, we don't have the ship, we can't survive on those small boats\n" +
        "It is the end of humanity\n" +
       "Time to say... Goodbye")
    {
        option1 = new Choice("Back to Main Menu", () => { MainMenu.BackToMainMenu(); }),
        option2 = new Choice("Close the game", () => { })//
    };

    public static Decision dead = new Decision("The End",
       "Oh God...it started pretty good, but now...\n" +
        "It is the end of humanity... We failed\n" +
       "Time to say... Goodbye")
    {
        option1 = new Choice("Back to Main Menu", () => { MainMenu.BackToMainMenu(); }),
        option2 = new Choice("Close the game", () => { })//
    };

    public static Decision notgoodend = new Decision("The End",
     "We have the ship, but there is not enough food for all of us\n" +
      "Probably, that won't be enough to survive on Eearth in global perspective\n" +
     "Well, at least... we'll try")
    {
        option1 = new Choice("Back to Main Menu", () => { MainMenu.BackToMainMenu(); }),
        option2 = new Choice("Close the game", () => { })//
    };

    public static Decision attitudeevent = new Decision("Some shit",
   "People demand more food, they say they can't work in current curcuimstances")
    {
        option1 = new Choice("Increase rations", () => { AttitudeChange(1); }),
        option2 = new Choice("Do nothing", () => { AttitudeChange(-2); })
    };




    public static void AttitudeChange(int change)
    {
        int temp = GameController.attitude;
        GameController.attitude += change;
        if (GameController.attitude > 2) GameController.attitude = 2;
        if (GameController.attitude < -2) GameController.attitude = -2;
        temp = (GameController.attitude - temp) * 110;
        GameObject.Find("Pointer").transform.localPosition += new Vector3(temp, 0, 0);
        GameController.UpdateInfo();
    }

    public static void ResourcesChange(int[] resources)
    {
        Production payment = new Production(resources[0], resources[1], resources[2], resources[3], resources[4]);
        GameController.resources += payment;
    }

}

