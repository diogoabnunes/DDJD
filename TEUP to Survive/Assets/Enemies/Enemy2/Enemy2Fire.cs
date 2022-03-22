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
        Instantiate(shot, transform.position + new Vector3(0, 1.3f, 0), transform.rotation); // top shot
        Instantiate(shot, transform.position - new Vector3(0, 1.3f, 0), transform.rotation); // bottom shot
    }

    public void SetFire(bool aux) {
        fire = aux;
    }
}
