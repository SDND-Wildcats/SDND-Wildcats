using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gateController : MonoBehaviour
{
    //Determines if win condition has been met
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (PlayerPrefs.GetInt("keyNum") == 10)
            {
                PlayerPrefs.SetInt("P4W", 1);
                Destroy(gameObject);
                SceneManager.LoadScene("ProjEnd");
            }
        }
    }
}
