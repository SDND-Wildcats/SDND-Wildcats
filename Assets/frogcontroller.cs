using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogcontroller : MonoBehaviour
{
    public Vector2 hVector;
    Vector2 myMove = new Vector2(1, 1);
    public float dotResult;
    int layerMask;
    bool engaged = false;
    float lastTime;
    public GameObject coinPrefab;


    void Start()
    {
        lastTime = Time.time;
        layerMask = 0xffff ^ (1 << LayerMask.NameToLayer("npcLayer"));
    }

    //Uses rays and lines to determine player position and shoot homing bullets
    void Update()
    {
        hVector = PlayerController4.position - (Vector2)transform.position;

        Debug.DrawLine(transform.position, PlayerController4.position, Color.black);
        Debug.DrawRay(transform.position, transform.right.normalized * 15f, Color.blue);

        if (!engaged)
        {
            transform.Find("rotator").Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
        }

        engaged = false;
        if (hVector.magnitude < 15f)
        {
            Debug.DrawLine(transform.position, PlayerController4.position, Color.green);
            RaycastHit2D hit;

            if (hit = Physics2D.Linecast(transform.position, PlayerController4.position, layerMask))
            {
                if (hit.collider.gameObject.name == "Player")
                {
                    if (Vector2.Dot(transform.Find("rotator").up.normalized, hVector.normalized) > dotResult)
                    {
                        Debug.DrawLine(transform.position, PlayerController4.position, Color.red);
                        transform.Find("rotator").up = hVector.normalized;
                        GetComponent<Rigidbody2D>().velocity = hVector.normalized * 1;
                        engaged = true;
                    }
                }
            }
        }

        if ((Time.time - lastTime) > 1)
        {
            GameObject temp;

            temp = Instantiate(coinPrefab, transform.Find("rotator").Find("arrow").position, Quaternion.identity);

            temp.GetComponent<Rigidbody2D>().velocity = transform.Find("rotator").up * 3;

            Destroy(temp, 3);

            lastTime = Time.time;
        }
    }
}
