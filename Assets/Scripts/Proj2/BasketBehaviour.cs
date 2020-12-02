using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BasketBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rawMouse = Input.mousePosition;

        Vector3 convertedMouse = Camera.main.ScreenToWorldPoint(rawMouse);

        Vector3 pos = transform.position;

        pos.x = convertedMouse.x;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "petal")
        {
            Destroy(collision.gameObject);
            GameObject.Find("Bounds").GetComponent<BoundScript>().IncrementScore();
        }
    }

}
