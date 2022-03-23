using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireSound : MonoBehaviour
{
    public static AudioClip fireSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("roar_trimmed");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 1.0f;
    }

    public void PlayPlayerFire ()
    {
        audioSrc.PlayOneShot (fireSound);
    }
}
