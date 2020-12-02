using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealController : MonoBehaviour
{
	//Declaring some stuff for future use
	public TextController booly;
	public GoalController booly2;

	//Function for moving up
	public void MoveUp(){
		Vector3 position = this.transform.position;
        if(position.y < 8)
        {
	        position.y++;
	        this.transform.position = position;
        }
        else
        {
        	print("you cant go there!");
        	GetComponent<AudioSource>().Play();
        }
	}

	//Function for moving down
	public void MoveDown(){
		Vector3 position = this.transform.position;
            if(position.y > -8)
            {
	            position.y--;
	            this.transform.position = position;
	        }
	        else
	        {
	        	print("you cant go there!");
	        	GetComponent<AudioSource>().Play();	        	
	        }
	}

	//Function for moving left
	public void MoveLeft(){
		Vector3 position = this.transform.position;
	        if(position.x > -15)
	        {
		        position.x--;
	            this.transform.position = position;
        	}
	        else
	        {
	        	print("you cant go there!");
	        	GetComponent<AudioSource>().Play();
	        }

	}

	//Function for moving right
	public void MoveRight(){
		Vector3 position = this.transform.position;
	        if(position.x < 15)
	        {
		        position.x++;
	            this.transform.position = position;
        	}
	        else
	        {
	        	print("you cant go there!");
	        	GetComponent<AudioSource>().Play();
	        }
	}

	void Update(){

        GameObject b = GameObject.Find("Goal");
        booly2 = b.GetComponent<GoalController> ();

		//Manages the visibility of the player (for flashlight)
		GameObject g = GameObject.Find("EventSystem");
        booly = g.GetComponent<TextController> ();
		if(booly.flashState == false){
			GetComponent<Renderer>().enabled = false;
		}
		else{
			GetComponent<Renderer>().enabled = true;
		}

		//Finds distance between player and goal
		Vector3 pos1 = this.transform.position;
        var pos2 = GameObject.Find("Goal").transform.position;
        float dist = Vector3.Distance (pos1, pos2);
		//Destroys player object if the key is posessed and on goal
		if(dist == 0){
            if(booly2.haveKey == true){
				Destroy(this.gameObject);
			}
		}
	}
}

