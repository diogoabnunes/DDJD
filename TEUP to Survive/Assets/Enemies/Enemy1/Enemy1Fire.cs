using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Fire : MonoBehaviour
{
    [SerializeField] private GameObject shot;
    [SerializeField] private float coolDown = 1f; // how much to wait for the next shot
    
    private float nextShot; // instant of the next shot

    void Start() {
        nextShot = 0f;
    }

    void Update()
    {
        if (CanShot()) {
            Shot();
            nextShot = Time.time + coolDown;
        }
    }

    bool CanShot() { // if it is stopped in X and if time has passed
        return Time.time > nextShot;
    }

    void Shot() {
        Instantiate(shot, transform.position, transform.rotation);
    }
}
