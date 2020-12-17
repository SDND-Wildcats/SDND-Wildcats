using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ensures bullets despawn on contact
        if (collision.gameObject.tag != "enemy" && collision.gameObject.tag != "bullet" && collision.gameObject.tag != "fountain")
        {
            Destroy(gameObject);
        }

    }

}
