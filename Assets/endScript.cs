using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScript : MonoBehaviour
{
    GameObject textOutput;
    Text directText;

    void Start()
    {
        textOutput = GameObject.Find("woowo");

    }

    //Displays whether you won or not when the game is over
    void Update()
    {
        int holynum = PlayerPrefs.GetInt("P4W");
        directText = textOutput.GetComponent<Text>();
        if(holynum == 1)
        {
            directText.text = ("You won! :D\nThanks for playing!?");
        }
        else
        {
            directText.text = ("You died :(\nWanna try again?");
        }
    }
}
