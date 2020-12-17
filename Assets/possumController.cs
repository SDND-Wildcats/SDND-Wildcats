using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possumController : MonoBehaviour
{
    public float treeSpeed = 2.0f;
    void Start()
    {
        Invoke("Direction", 1.5f);
    }

    //Makes the possums face the correct direction
    void Update()
    {
        transform.Translate(treeSpeed * Time.deltaTime, 0, 0);

        if (treeSpeed > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        if (treeSpeed < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    //Handles direction changes
    void Direction()
    {
        float val = Random.value;
        if (val >= .9f)
        {
            treeSpeed *= -1.0f;
        }

        Invoke("Direction", 0.3f);
    }

    //Handles direction changes
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            treeSpeed *= -1.0f;
        }
    }

}
