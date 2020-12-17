using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textscript : MonoBehaviour
{
    GameObject textOutput;
    Text directText;

    void Start()
    {
        textOutput = GameObject.Find("KeyThing");

    }

    void Update()
    {
        //Displays how many keys are left to find
        int holynum = PlayerPrefs.GetInt("keyNum");
        int holiernum = 10 - holynum;
        directText = textOutput.GetComponent<Text>();
        directText.text = ("Keys Remaining: " + holiernum);
    }
}
