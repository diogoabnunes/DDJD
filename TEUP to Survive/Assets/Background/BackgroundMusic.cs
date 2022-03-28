using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static AudioClip teupSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        teupSound = Resources.Load<AudioClip>("teup");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 1.0f;
        audioSrc.loop = true;
        audioSrc.clip = teupSound;
        audioSrc.Play();
    }
}
