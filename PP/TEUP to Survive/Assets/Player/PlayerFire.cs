using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject tigerShot;
    [SerializeField] private float coolDown = 0.5f;
    private float nextShot;

    void Start()
    {
        nextShot = 0f;
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
        Instantiate(tigerShot, transform.position + new Vector3(0.6f, 0.3f, 0), transform.rotation);
    }

    public void SetShotCoolDown(float newCoolDown){
        coolDown = newCoolDown;
    }

    public float GetCoolDown(){
        return coolDown;
    }
}
