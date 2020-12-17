using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpjump : MonoBehaviour
{
    //Allows for collection of the powerup
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
