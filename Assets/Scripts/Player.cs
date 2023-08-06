using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float gravity;

    private Rigidbody2D rb;
    private bool isJumping;

    [SerializeField] float maxVelocityY;

    [SerializeField] int maxJump;
    [SerializeField] int curJump;
    public bool gm;
    public GameObject sp1, sp2; 
    public int jumpBars;

    public gameManager gn;
    public Image[] Sprites;
    public Sprite full;
    public Sprite empty;

    public Animator anim;
    public bool  FaceRight;

    public GameObject explosion;
    public Animator camAnim;

    public bool cantDead;

    public bool canStart;

    public TextMeshProUGUI controls;

    public bool hasPlayed = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curJump = maxJump;

        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (cameraObject != null)
        {
            camAnim = cameraObject.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (gm == true && hasPlayed == false)
        {
            MusicManager.mm.Audio.Stop();
            MusicManager.mm.Audio.PlayOneShot(MusicManager.mm.AttackMusic);
            hasPlayed = true;
        } 

        if (rb.velocity.y < 0 && isJumping == false)
        {
            anim.SetBool("isFalling", true);
        } else
        {
            anim.SetBool("isFalling", false);
        }
        for(int i = 0; i < Sprites.Length; i++)
        {
            if(i < curJump)
            {
                Sprites[i].enabled = true;
            } else
            {
                Sprites[i].enabled = false;
            }
        }
       
            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.C)) && curJump > 0 && canStart)
            {
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                if (curJump > 0 && gm == true)
                {
                    curJump--;
                
            }



            SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.Jump2);
            anim.SetTrigger("Jump");
            anim.SetBool("isFalling", false);

            if (gm == false)
            {
                gm = true;
                KillCounter.KillCount = 0;
                MusicManager.mm.Audio.Stop();

            }
           

            if(!sp1.activeSelf && !sp2.activeSelf)
            {
                sp1.SetActive(true);
                sp2.SetActive(true);
            }

            }
            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }

            if(gm)
        {
   
            float moveInput = Input.GetAxis("Horizontal");
        
            if (moveInput > 0 && !FaceRight)
            {
                Flip();
            }
            if (moveInput < 0 && FaceRight)
            {
                Flip();
            }
            rb.velocity = new Vector2(moveInput * horizontalSpeed, rb.velocity.y);


            rb.velocity += Vector2.down * gravity * Time.deltaTime;

            controls.enabled = false;
        }

        


    }

    private void FixedUpdate()
    {

        Vector2 velocity = rb.velocity;


        velocity.y = Mathf.Clamp(velocity.y, -maxVelocityY, maxVelocityY);


        rb.velocity = velocity;
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        if (curJump < maxJump)
        {
            curJump++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {

            StartCoroutine(playerDeath());
            

        }
    }

    IEnumerator playerDeath()
    {
        MusicManager.mm.Audio.Stop();
        SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.hitStop);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(.5f);
        Time.timeScale = 1;
        SoundManager.sm.Audio.PlayOneShot(SoundManager.sm.Death);
        camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        gn.hasStarted = true;
        Destroy(gameObject);
    }

    public void Flip()
    {
        Vector3 curScale = gameObject.transform.localScale;
        curScale.x *= -1;
        gameObject.transform.localScale = curScale;

        FaceRight = !FaceRight;

    }


}

