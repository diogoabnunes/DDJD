using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject tigerShot;
    [SerializeField] private float coolDown = 0.5f;
    private float nextShot;
    private PlayerFireSound playerFireSound;

    void Start()
    {
        nextShot = 0f;
        playerFireSound = FindObjectsOfType<PlayerFireSound>()[0];
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && CanShot()){
            Shot();
            nextShot = Time.time + coolDown;
        }
    }

    private bool CanShot() {
        return Time.time > nextShot;
    }

    private void Shot() {
        Instantiate(tigerShot, transform.position, transform.rotation);
        playerFireSound.PlayPlayerFire();
    }

    public void SetShotCoolDown(float newCoolDown){
        coolDown = newCoolDown;
    }

    public float GetCoolDown(){
        return coolDown;
    }
}
