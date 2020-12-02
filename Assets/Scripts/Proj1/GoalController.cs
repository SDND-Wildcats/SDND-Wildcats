using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{

    //Declaring some stuff for future use
   	public TextController booly2;
    GameObject textOutput;
    Text directText;
    public bool haveKey;
    AudioSource m_MyAudioSource;

    void Start(){
        //Finds the text to edit on start
        textOutput = GameObject.Find("Description");
    }
    void Update()
    {
        //Finds distance between the goal and the player
        Vector3 pos1 = this.transform.position;
        var pos2 = GameObject.Find("rpiSeal").transform.position;
        float dist = Vector3.Distance (pos1, pos2);

        //Checks if the player is at the goal
        if(dist == 0){
            //Checks if player has key
            if(haveKey == true){
                directText = textOutput.GetComponent<Text>();
                GetComponent<AudioSource>().Play();
                directText.text = "you escaped!";
                print("you escaped!");
                this.enabled = false;
            }
            //Called if player does not have key
            else{
                print("it looks like you need a key...");
                directText = textOutput.GetComponent<Text>();
                directText.text = "it looks like you need a key...";
            }
        }        
    }
}
