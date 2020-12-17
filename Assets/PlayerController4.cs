using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController4 : MonoBehaviour
{
    static public Vector2 position;
    AudioSource audioData;

    void Start()
    {
        //Sets powerups to inactive on start
        PlayerPrefs.SetInt("megaJump", 0);
        PlayerPrefs.SetInt("keyNum", 0);
        PlayerPrefs.SetInt("P4W", 0);

        audioData = GetComponent<AudioSource>();
        //audioData.Play(0);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -45)
        {
            SceneManager.LoadScene("ProjEnd");
        }

        position = transform.position;

        //Detects if powerup is activated
        if (PlayerPrefs.GetInt("megaJump") == 1)
        {
            GetComponent<Animator>().SetBool("Grounded", true);
        }

        //Handles movement of main character
        Vector2 heroMovement;
        heroMovement = new Vector2(
            Input.GetAxisRaw("Horizontal") * 6f,
            GetComponent<Rigidbody2D>().velocity.y
            );

        GetComponent<Rigidbody2D>().velocity = heroMovement;

        GetComponent<Animator>().SetFloat("xVel", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        //Rotates game sprite appropriately
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Handles jump inputs
        if (Input.GetButtonDown("Jump"))
           if (GetComponent<Animator>().GetBool("Grounded") == true)
           {
                {
                    GetComponent<Rigidbody2D>().AddForce(transform.up * 6f, ForceMode2D.Impulse);
                    GetComponent<Animator>().SetBool("Grounded", false);
                    audioData.Play(0);
                }
            }
    }

    //Handles collision with enemies causing death
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("Grounded", true);

        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "bullet")
        {
            if (PlayerPrefs.GetInt("megaJump") == 0)
            {
                SceneManager.LoadScene("ProjEnd");
            }
        }

    }
}
