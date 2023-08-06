using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public bool hasStarted;
    public Enemy enemy;
    public static int hiddenCount;
    public Animator anim;
    public bool za;

    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            
            StartCoroutine(Death());
            enemy.movementSpeed = 3f;

        }

        if(hiddenCount == 10 && enemy.movementSpeed < 6)
        {
            enemy.movementSpeed += 0.1f;
            hiddenCount = 0;
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("Start");
        
        yield return new WaitForSeconds(1f);

    }


}
