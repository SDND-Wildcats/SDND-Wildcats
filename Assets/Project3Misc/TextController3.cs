using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController3 : MonoBehaviour
{
    GameObject textOutput;
    Text directText;

    void Start()
    {
        //print(PlayerPrefs.GetInt("PlayerScore"));
        textOutput = GameObject.Find("ScoreTrack");
        directText = textOutput.GetComponent<Text>();
        directText.text = PlayerPrefs.GetInt("PS3").ToString();

        textOutput = GameObject.Find("ScoreTrack2");
        directText = textOutput.GetComponent<Text>();
        directText.text = PlayerPrefs.GetInt("HS3").ToString();
    }
}
