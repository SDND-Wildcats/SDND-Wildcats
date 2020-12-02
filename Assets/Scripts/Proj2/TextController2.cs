using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController2 : MonoBehaviour
{

    GameObject textOutput;
    Text directText;

    void Start()
    {
        //print(PlayerPrefs.GetInt("PlayerScore"));
        textOutput = GameObject.Find("ScoreTrack");
        directText = textOutput.GetComponent<Text>();
        directText.text = PlayerPrefs.GetInt("PlayerScore").ToString();

    }

}
