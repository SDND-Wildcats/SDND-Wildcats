using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
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
        int PU1 = PlayerPrefs.GetInt("PU1");
        //int PU2 = PlayerPrefs.GetInt("PU2");
        if(PU1 == 1)
        {
            if (collision.gameObject.tag != "enemy" && collision.gameObject.tag != "bullet")
            {
                Destroy(gameObject);
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
