using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    //Declaring some stuff for future use
    AudioSource m_MyAudioSource;
    public GoalController booly;

    void Update()
    {
        GameObject g = GameObject.Find("Goal");
        booly = g.GetComponent<GoalController> ();

        //Calculates distance between player and goal
        Vector3 pos1 = this.transform.position;
        var pos2 = GameObject.Find("rpiSeal").transform.position;
        float dist = Vector3.Distance (pos1, pos2);

        //Manages the dynamic volume depending on distance
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.volume = 1/dist;

        //Destroys the gate sprite if game completed
        if(dist == 0){
            if(booly.haveKey == true){
                Destroy(this.gameObject);
            }
        }
        
    }
}
