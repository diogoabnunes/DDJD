using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    [SerializeField] private int numOfAnimations;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetInteger("AnimationSelected",Random.Range(0,numOfAnimations));
    }

}
