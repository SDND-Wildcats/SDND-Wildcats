using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    //Declaring some stuff for future use
    public GoalController booly;
  	public TextController booly2;
    GameObject key;
    GameObject textOutput;
    Text directText;

    void Start()
    {
        //Finds text to edit and sets up some variables for later
        textOutput = GameObject.Find("Description");
        GameObject g = GameObject.Find("Goal");
        booly = g.GetComponent<GoalController> ();
        booly.haveKey = false;
    }
    void Update()
    {
        //Finds distance between player and key
        Vector3 pos1 = this.transform.position;
        var pos2 = GameObject.Find("rpiSeal").transform.position;
        float dist = Vector3.Distance (pos1, pos2);

        //Called if player is on key
        if(dist == 0){
            directText = textOutput.GetComponent<Text>();
            directText.text = "you found a key!";
            print("you found a key!");
            //Changes boolean and destroys object if key is found
            booly.haveKey = true;
            Destroy(this.gameObject);
        }

    }
}
