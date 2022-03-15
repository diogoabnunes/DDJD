using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private int numRounfOfShots = 3;
    [SerializeField] private float durationOfShooting = 3f;
    [SerializeField] private float timeBetweeenShooting = 3f;

    private float nextShot;
    private float stopShooting;
    private bool isShooting;
    private float timeToDie;

    void Start()
    {
        nextShot = Time.time + 3f;
        stopShooting = 10f;
        isShooting = false;
        timeToDie = -1f;        
    }

    void Update()
    {
        if (Time.time > nextShot && timeToDie == -1) {
            nextShot = Time.time + durationOfShooting + timeBetweeenShooting;
            stopShooting = Time.time + durationOfShooting;
            isShooting = true;

            GetComponent<Enemy2Fire>().SetFire(true);
            GetComponent<Enemy2Movement>().LockMovement();
        }

        if (Time.time > stopShooting && isShooting && timeToDie == -1) {
            GetComponent<Enemy2Fire>().SetFire(false);
            GetComponent<Enemy2Movement>().UnlockMovement();

            numRounfOfShots--;
            isShooting = false;
        }

        if (numRounfOfShots == 0 && timeToDie == -1) timeToDie = Time.time + 2f;

        if (timeToDie != -1 && Time.time > timeToDie) Die();
    }

    void Die() {
        // disable components
        GetComponent<Enemy2Fire>().enabled = false;
        GetComponent<Enemy2Movement>().enabled = false;

        // go down the screen
        GetComponent<Rigidbody2D>().gravityScale = 3;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "BottomOutScene") Destroy(this.gameObject);
    }
}
