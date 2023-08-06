using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Jump;
    public AudioClip Jump2;
    public AudioClip Jump3;
    public AudioClip Stomp;
    public AudioClip hitStop;
    public AudioClip Death;
    public static SoundManager sm;

    void Awake()
    {
        if (sm != null && sm != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sm = this;
        DontDestroyOnLoad(this);
    }


}
