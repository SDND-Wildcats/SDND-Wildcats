using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaJump : MonoBehaviour
{
    //Powerup functionality
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("megaJump", 1);
            Destroy(gameObject);
        }

    }


}