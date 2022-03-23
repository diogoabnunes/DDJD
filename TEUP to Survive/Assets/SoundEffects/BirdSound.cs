using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSound : MonoBehaviour
{
    public static AudioClip jetpackSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jetpackSound = Resources.Load<AudioClip>("bird");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0.0f;
        audioSrc.loop = true;
        audioSrc.clip = jetpackSound;
        audioSrc.Play();
    }

    public void On()
    {
        audioSrc.volume = 1.0f;
    }
    
    public void Off()
    {
        audioSrc.volume = 0.0f;
    }
}
