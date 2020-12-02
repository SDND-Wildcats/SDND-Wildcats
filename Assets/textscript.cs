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

    // Update is called once per frame
    void Update()
    {
        int holynum = PlayerPrefs.GetInt("keyNum");
        int holiernum = 5 - holynum;
        directText = textOutput.GetComponent<Text>();
        directText.text = ("Keys Remaining: " + holiernum);
    }
}
