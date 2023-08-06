using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    Player player;
    public GameObject explosion;
    public Animator camAnim;
   

    void Start()
    {
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }

        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (cameraObject != null)
        {
            camAnim = cameraObject.GetComponent<Animator>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stomp"))
        {
            if (player != null)
            {
                SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.Stomp);
                camAnim.SetTrigger("shake");
                Instantiate(explosion, transform.parent.position, Quaternion.identity);
                Destroy(transform.parent.gameObject);
                player.Bounce();
                player.anim.SetTrigger("Stomp");
                KillCounter.KillCount++;
                gameManager.hiddenCount++;
            }
        }
    }

    public void Dexplode()
    {
        Destroy(gameObject);
    }

  

}
