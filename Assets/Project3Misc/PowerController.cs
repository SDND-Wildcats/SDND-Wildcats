using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
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
        if (collision.gameObject.tag == "heroCoin")
        {
            PlayerPrefs.SetInt("PU1", 1);
            Invoke("unPower", 10);
            gameObject.SetActive(false);
        }

    }

    void unPower()
    {
        PlayerPrefs.SetInt("PU1", 0);
        Destroy(gameObject);
    }

}