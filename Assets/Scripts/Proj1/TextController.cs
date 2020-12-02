using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    //Declaring some stuff for future use
    GameObject textOutput;
    GameObject batText;
    GameObject moveText;
    Text directText;
    public bool flashState = false;
    int batRem = 100;
    int moves = 0;

    void Start(){
        //Getting the text objects ready for use
        textOutput = GameObject.Find("Description");
        batText = GameObject.Find("Battery Level");
        moveText = GameObject.Find("Move Count");
    }

    //Called if the player moves closer to the goal
    public void closer(){
        moves = moves + 1;
        directText = textOutput.GetComponent<Text>();
        directText.text = "the sound of the ocean gets louder...";
        directText = moveText.GetComponent<Text>();
        directText.text = moves.ToString();
    }

    //Called if the player moves closer to the goal
    public void further(){
        moves = moves + 1;
        directText = textOutput.GetComponent<Text>();
        directText.text = "the sound of the ocean gets quieter...";
        directText = moveText.GetComponent<Text>();
        directText.text = moves.ToString();
    }

    //Manages flashlight battery/toggle
    public void ToggleLight(bool state){
        if(batRem > 0){
            batRem = batRem - 5;
            flashState = state;
            print("toggle state is: " + state);
        }
        else{
            flashState = false;
            print("you have run out of battery...");
        }
        directText = batText.GetComponent<Text>();
        directText.text = batRem.ToString();
    }

    //Manages text for flashlight battery
    public void LookAround(){
        if (!flashState){
            print("its dark...");
        }
        else{
            batRem = batRem -5;
            print("!");
            directText = batText.GetComponent<Text>();
            directText.text = batRem.ToString();
            print("the room is illuminated..!");
        }
    }

    //Ensures the light stays off if the battery is 0
    void Update(){
        if (batRem < 1){
            flashState = false;
        }
    }

}
