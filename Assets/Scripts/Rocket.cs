using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float rocketSpeed = 5f;

    private Rigidbody2D rb;

    public bool moveUp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();



        if(moveUp)
        {
            rb.velocity = Vector2.up * rocketSpeed;
        } else
        {
            rb.velocity = Vector2.down * rocketSpeed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ArrivalIndicator"))
        {

            gameObject.SetActive(false);
        }
    }
}
