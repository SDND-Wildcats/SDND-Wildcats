using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evelatorController : MonoBehaviour
{
    //Handles elevator speed
    public float treeSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //Handles elevator speed
        transform.Translate(0, treeSpeed * Time.deltaTime, 0);

        //Changes elevator direction
        if (transform.position.y > 0)
        {
            treeSpeed *= -1.0f;
        }
    }

    //Changes elevator direction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            treeSpeed *= -1.0f;
        }
    }
}
