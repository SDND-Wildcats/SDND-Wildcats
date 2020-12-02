using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class CharControl : MonoBehaviour
{
    public int highscore;
    public int score;
    public int difficulty;
    public float trueDif;
    float lastTime;
    static public Vector2 position;
    //int powerUp1 = 0;
    //int powerUp2 = 0;
    int lives = 3;
    public GameObject coinPrefab;
    public GameObject molePrefab;
    public GameObject treePrefab;
    public GameObject deathPrefab;
    public GameObject heartPrefab;
    public GameObject gemPrefab;



    void Start()
    {
        highscore = PlayerPrefs.GetInt("HS3", 10000);
        PlayerPrefs.SetInt("PU1", 0);
        PlayerPrefs.SetInt("PU2", 0);
        //GameObject.Find("Highscore").GetComponent<Text>().text = highscore.ToString();
        score = 0;
        PlayerPrefs.SetInt("PS3", score);
        difficulty = 100;
        PlayerPrefs.SetInt("Dif", difficulty);
        //GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
        //PopulateNPCs();
        PopulateNPCs2();
        PowerUp();
    }

    // Update is called once per frame
    void Update()
    {

        score = PlayerPrefs.GetInt("PS3");
        highscore = PlayerPrefs.GetInt("HS3");
        difficulty = PlayerPrefs.GetInt("Dif");

        trueDif = difficulty / 100f;

        GameObject.Find("ScoreN").GetComponent<Text>().text = score.ToString();
        GameObject.Find("LivesN").GetComponent<Text>().text = lives.ToString();
        GameObject.Find("DifficultyN").GetComponent<Text>().text = trueDif.ToString();

        //trueDif = difficulty / 100f;

        position = transform.position;

        Vector2 myMove;

        myMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        GetComponent<Rigidbody2D>().velocity = myMove*3;

        GetComponent<Animator>().SetFloat("yVelocity", (GetComponent<Rigidbody2D>().velocity.y));
        GetComponent<Animator>().SetFloat("xVelocity", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.magnitude > .05)
        GetComponent<SpriteRenderer>().flipX = (GetComponent<Rigidbody2D>().velocity.x < 0);
    
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp;
            Vector3 mousePos = Input.mousePosition;
            Vector3 direct;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            mousePos.z = transform.position.z;

            direct = mousePos - transform.position;

            direct = direct.normalized;

            temp = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().velocity = direct*10;
            if(PlayerPrefs.GetInt("PU1") == 1)
            {
                temp.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                temp.GetComponent<Rigidbody2D>().velocity = direct * 20;
            }


            //Destroy(temp, 3f);
            lastTime = Time.time;
        }
        Vector3 scaleChange, scale;
        scaleChange = new Vector3(15f, 15f, 1f);
        scale = new Vector3(7f, 7f, 1f);
        if (PlayerPrefs.GetInt("PU2") == 1)
        {
            transform.localScale = scaleChange;
            GetComponent<Rigidbody2D>().velocity = myMove * 10;
        }
        else
        {
            transform.localScale = scale;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (PlayerPrefs.GetInt("PU2") == 0)
        {
            if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet")
            {
                lives = lives - 1;
                GameObject temp2;
                temp2 = Instantiate(deathPrefab, transform.position, Quaternion.identity);
                Destroy(temp2, .5f);

                if(lives >= 1)
                {
                    gameObject.transform.position = new Vector3(0, -3, 0);
                }
                else
                {
                    Destroy(GameObject.Find("hero"));
                    SceneManager.LoadScene("Proj3End");
                }

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
                foreach (GameObject enemy in enemies)
                {
                    GameObject.Destroy(enemy);
                }
                GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("bullet");
                foreach (GameObject enemy2 in enemies2)
                {
                    GameObject.Destroy(enemy2);
                }

            }
        }

    }

    void PopulateNPCs()
    {
        GameObject tempN;

        Vector2 cSize = treePrefab.GetComponent<BoxCollider2D>().size;

        float chooser = Random.Range(-1f, 1f);

        float trueDif = PlayerPrefs.GetInt("Dif") / 100f;

        float spawnTime = 2f / trueDif;

        //print(spawnTime);

        Vector2 tempPos;
        do
        {
            tempPos = new Vector2(Random.Range(-13f, 13f), Random.Range(3f, 4f));
        }
        while (Physics2D.OverlapBox(tempPos, cSize, 0f) != null);
        {
            tempN = Instantiate(treePrefab, tempPos, Quaternion.identity);
        }

        if (chooser > 0)
        {
            Invoke("PopulateNPCs", spawnTime);
        }
        else
        {
            Invoke("PopulateNPCs2", spawnTime);
        }

    }


    void PopulateNPCs2()
    {
        GameObject tempN;

        Vector2 cSize = molePrefab.GetComponent<BoxCollider2D>().size;

        float chooser = Random.Range(-1f, 1f);

        float trueDif = PlayerPrefs.GetInt("Dif") / 100f;

        float spawnTime = 2f / trueDif;

        //print(spawnTime);

        Vector2 tempPos;
        do
        {
            if (chooser > 0)
            {
                tempPos = new Vector2(Random.Range(-14f, -12f), Random.Range(-7f, 1f));
            }
            else
            {
                tempPos = new Vector2(Random.Range(12f, 14f), Random.Range(-7f, 1f));
            }
        }
        while (Physics2D.OverlapBox(tempPos, cSize, 0f) != null);
        {
            tempN = Instantiate(molePrefab, tempPos, Quaternion.identity);
        }

        if (chooser > 0)
        {
            Invoke("PopulateNPCs", spawnTime);
        }
        else
        {
            Invoke("PopulateNPCs2", spawnTime);
        }
    }

    void PowerUp()
    {
        GameObject tempN;

        float chooser = Random.Range(-1f, 1f);

        Vector2 cSize = molePrefab.GetComponent<BoxCollider2D>().size;

        Vector2 tempPos;

        do
        {
            tempPos = new Vector2(Random.Range(-12f, 12f), Random.Range(-7f, -5f));
        }
        while (Physics2D.OverlapBox(tempPos, cSize, 0f) != null) ;
        {
            if (chooser > 0)
            {
                tempN = Instantiate(gemPrefab, tempPos, Quaternion.identity);
            }
            else
            {
                tempN = Instantiate(heartPrefab, tempPos, Quaternion.identity);
            }
        }
       
        Invoke("PowerUp", 20);
    }

}
