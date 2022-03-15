using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Fire : MonoBehaviour
{
    [SerializeField] private GameObject shot;
    [SerializeField] private float coolDown = 0.1f;

    private float nextShot;
    private bool fire;

    void Start()
    {
        nextShot = 0f;
        fire = false;
    }

    void Update()
    {
        if (CanShot()) {
            Shot();
            nextShot = Time.time + coolDown;
        }
    }

    bool CanShot() { // if it is stopped in X and if time has passed
        return Time.time > nextShot && fire;
    }

    void Shot() {
        Instantiate(shot, transform.position, transform.rotation);
    }

    public void SetFire(bool aux) {
        fire = aux;
    }
}
