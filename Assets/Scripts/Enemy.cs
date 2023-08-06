using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool moveRight = true;
    public float movementSpeed = 3f;


    private void Update()
    {

        float direction = moveRight ? 1f : -1f;



        transform.Translate(Vector2.right * direction * movementSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Killer")
        {
            Destroy(gameObject);
        }
    }



}
