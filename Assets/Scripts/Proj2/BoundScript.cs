using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class BoundScript : MonoBehaviour
{

    public int score;

    public int highscore;

    private List<GameObject> basketList;

    private AudioSource[] audioSrcs;

    public GameObject basketPrefab;

    void Start()
    {
        audioSrcs = GetComponents<AudioSource>();

        highscore = PlayerPrefs.GetInt("HS", 1000);
        GameObject.Find("Highscore").GetComponent<Text>().text = highscore.ToString();
        score = 0;
        PlayerPrefs.SetInt("PlayerScore", score);
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString();


        basketList = new List<GameObject>();

        float bottomEdge = transform.position.y + 0.5f;

        for (int i = 0; i < 3; i++)
        {
            GameObject basket = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = basket.transform.position;
            pos.y = bottomEdge + (i * 0.5f);
            basket.transform.position = pos;
            basketList.Add(basket);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void IncrementScore()
    {
        score += 100;

        audioSrcs[1].Play();

        if(score > highscore)
        {
            highscore = score;
            GameObject.Find("Highscore").GetComponent<Text>().text = score.ToString();
        }

        GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
    }

    private void RestartScene()
    {
        PlayerPrefs.SetInt("HS", highscore);
        PlayerPrefs.SetInt("PlayerScore", score);
        SceneManager.LoadScene("Proj2End");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "petal")
        {
            audioSrcs[0].Play();
            int topBasket = basketList.Count - 1;
            if (topBasket > -1)
            {
                Destroy(basketList[topBasket]);
                basketList.RemoveAt(topBasket);
            }

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("petal");
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }

            if (topBasket <= 0)
            {
                Destroy(GameObject.Find("CBTree"));
                Invoke("RestartScene", 1);
            }

            //Destroy(collision.gameObject);
            //print("nyoom");
        }

    }
}
