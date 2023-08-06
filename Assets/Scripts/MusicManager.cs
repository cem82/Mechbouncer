using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AttackMusic;
    public AudioClip calmMusic;
    public static MusicManager mm;

    void Awake()
    {
        if (mm != null && mm != this)
        {
            Destroy(this.gameObject);
            return;
        }

        mm = this;
        DontDestroyOnLoad(this);
    }

}
