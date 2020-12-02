using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evelatorController : MonoBehaviour
{
    public float treeSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, treeSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            treeSpeed *= -1.0f;
        }
    }
}
