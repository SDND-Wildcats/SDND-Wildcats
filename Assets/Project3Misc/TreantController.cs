using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantController : MonoBehaviour
{
    public Vector2 hVector;
    Vector2 myMove = new Vector2(1, 1);
    public float dotResult;
    int layerMask;
    bool engaged = false;
    float lastTime;
    public GameObject coinPrefab;
    public GameObject deathPrefab;


    // Start is called before the first frame update
    void Start()
    {
        layerMask = 0xffff ^ (1 << LayerMask.NameToLayer("npcLayer"));
        lastTime = Time.time;

        myMove = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        myMove = myMove.normalized;
        GetComponent<Rigidbody2D>().velocity = myMove * 1;
    }

    // Update is called once per frame
    void Update()
    {
        hVector = CharControl.position - (Vector2)transform.position;

        Debug.DrawLine(transform.position, CharControl.position, Color.black);
        Debug.DrawRay(transform.position, transform.right.normalized * 5f, Color.blue);

        if (!engaged)
        {
            transform.Find("rotator").Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
        }

        engaged = false;
        if(hVector.magnitude < 5f)
        {
            Debug.DrawLine(transform.position, CharControl.position, Color.green);
            RaycastHit2D hit;

            if(hit = Physics2D.Linecast(transform.position, CharControl.position, layerMask))
            {
                if(hit.collider.gameObject.name == "hero")
                {
                    if (Vector2.Dot(transform.Find("rotator").up.normalized, hVector.normalized) > dotResult)
                    {
                        Debug.DrawLine(transform.position, CharControl.position, Color.red);
                        transform.Find("rotator").up = hVector.normalized;
                        GetComponent<Rigidbody2D>().velocity = hVector.normalized * 1;
                        engaged = true;
                    }
                }
            }
        }

        //if (engaged)
        //{
            if ((Time.time - lastTime) > 1)
            {
                GameObject temp;

                temp = Instantiate(coinPrefab, transform.Find("rotator").Find("arrow").position, Quaternion.identity);

                temp.GetComponent<Rigidbody2D>().velocity = transform.Find("rotator").up * 3;

                //Destroy(temp, 3f);
                lastTime = Time.time;
            }
        //}
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "heroCoin")
        {
            GameObject temp2;
            temp2 = Instantiate(deathPrefab, transform.position, Quaternion.identity);
            Destroy(temp2, .5f);
            IncrementScore();
            Destroy(gameObject);
        }
    }

    public void IncrementScore()
    {
        int score = PlayerPrefs.GetInt("PS3");
        int highscore = PlayerPrefs.GetInt("HS3");
        int difficulty = PlayerPrefs.GetInt("Dif");
        score += 100;
        difficulty += 3;
        PlayerPrefs.SetInt("Dif", difficulty);
        PlayerPrefs.SetInt("PS3", score);

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HS3", highscore);
        }
    }

}
