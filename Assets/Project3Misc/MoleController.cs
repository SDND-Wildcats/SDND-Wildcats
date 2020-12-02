using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{

    public GameObject deathPrefab;
    Vector2 myMove = new Vector2(1,1);

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 randomDirection = new Vector3(Random.Range(-359, 359), Random.Range(-359, 359), Random.Range(-359, 359));
        //transform.Rotate(randomDirection);
        myMove = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        myMove = myMove.normalized;
        GetComponent<Rigidbody2D>().velocity = myMove * 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "heroCoin")
        {
            GameObject temp;
            temp = Instantiate(deathPrefab, transform.position, Quaternion.identity);
            Destroy(temp, .5f);
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
        difficulty += 2;
        PlayerPrefs.SetInt("Dif", difficulty);
        PlayerPrefs.SetInt("PS3", score);

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HS3", highscore);
        }
    }


}
