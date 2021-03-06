﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    //Allows for key collection and counting
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("keyNum", (PlayerPrefs.GetInt("keyNum") + 1));
            audioData.Play(0);
            Destroy(gameObject);
        }

    }
}
