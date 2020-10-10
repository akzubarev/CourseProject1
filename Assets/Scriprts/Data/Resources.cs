using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lib;

public class Resources : MonoBehaviour
{
    public static Slider scienceslider;
    public static Text wood,
                iron,
                food,
                people,
                science;
    void Awake()
    {
        wood = GameObject.Find("ResourseInfo/Wood").GetComponent<Text>();
        iron = GameObject.Find("ResourseInfo/Iron").GetComponent<Text>();
        food = GameObject.Find("ResourseInfo/Food").GetComponent<Text>();
        science = GameObject.Find("ResourseInfo/Science").GetComponent<Text>();
        scienceslider = GameObject.Find("ScienceSlider").GetComponent<Slider>();
        people = GameObject.Find("ResourseInfo/People").GetComponent<Text>();
    }

    public static void UpdateResources
        (Production resources, Production income)
    {
        string woodinctext = "(",
               ironinctext = "(",
               foodinctext = "(",
               scienceinctext = "(+",
               peopleinctext = "(";
        if (income.Wood >= 0) woodinctext += "+";
        if (income.Iron >= 0) ironinctext += "+";
        if (income.Food >= 0) foodinctext += "+";
        if (income.Humans >= 0) peopleinctext += "+";
        woodinctext += income.Wood + ")";
        ironinctext += income.Iron + ")";
        foodinctext += income.Food + ")";
        scienceinctext += income.Science + ")";
        peopleinctext += income.Humans + ")";


        wood.text = "Wood " + resources.Wood + woodinctext;
        iron.text = "Iron " + resources.Iron + ironinctext;
        food.text = "Food " + resources.Food + foodinctext;
        science.text = "Science " + resources.Science + scienceinctext;
        people.text = "People " + resources.Humans + peopleinctext;

        scienceslider.value = resources.Science;
    }

}


