using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gateController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (PlayerPrefs.GetInt("keyNum") == 5)
            {
                PlayerPrefs.SetInt("P4W", 1);
                Destroy(gameObject);
                SceneManager.LoadScene("Proj4End");
            }
        }
    }
}
