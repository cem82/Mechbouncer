using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AniEvent : MonoBehaviour
{
    public Player player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
    }
    
    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
    public void music()
    {
        
        MusicManager.mm.Audio.PlayOneShot(MusicManager.mm.calmMusic);
        player.canStart = true;



    }
}
