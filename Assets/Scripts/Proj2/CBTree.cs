using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class CBTree : MonoBehaviour
{
    public float treeSpeed = 2.0f;
    public GameObject petalPrefab;



    void Start()
    {
        Invoke("dropPetal", 1.0f);

        Invoke("Direction", 1.5f);

    }

    void Direction()
    {
        float val = Random.value;
        if(val >= .9f)
        {
            treeSpeed *= -1.0f;
        }

        Invoke("Direction", 0.3f);
    }

    void dropPetal()
    {
        GameObject petal = Instantiate <GameObject>(petalPrefab);

        petal.transform.position = transform.position;
        petal.GetComponent<Rigidbody2D>().AddTorque(2.0f);

        Invoke("dropPetal", Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(treeSpeed * Time.deltaTime, 0, 0);

        //if (Mathf.Abs(transform.position.x) > 4.5f){treeSpeed *= -1.0f;}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bounds")
        {
            treeSpeed *= -1.0f;
        }
    }


}
