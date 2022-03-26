using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    [SerializeField] private int numRounfOfShots = 3;
    [SerializeField] private float durationOfShooting = 3f;
    [SerializeField] private float timeBetweeenShooting = 3f;

    private float nextShot;
    private float stopShooting;
    private bool isShooting;
    private float timeToDie;
    private bool died;

    public Spawn spawn;

    void Start()
    {
        nextShot = Time.time + 3f;
        stopShooting = 10f;
        isShooting = false;
        timeToDie = -1f;
        died = false;

        spawn = FindObjectsOfType<Spawn>()[0];        
    }

    void Update()
    {
        if (Time.time > nextShot && timeToDie == -1) {
            nextShot = Time.time + durationOfShooting + timeBetweeenShooting;
            stopShooting = Time.time + durationOfShooting;
            isShooting = true;

            GetComponent<TeacherFire>().SetFire(true);
            GetComponent<TeacherMovement>().LockMovement();
        }

        if (Time.time > stopShooting && isShooting && timeToDie == -1) {
            GetComponent<TeacherFire>().SetFire(false);
            GetComponent<TeacherMovement>().UnlockMovement();

            numRounfOfShots--;
            isShooting = false;
        }

        if (numRounfOfShots == 0 && timeToDie == -1) timeToDie = Time.time + 2f;

        if (timeToDie != -1 && Time.time > timeToDie && !died) Die();
    }

    void Die() {
        died = true;

        // disable components
        GetComponent<TeacherFire>().enabled = false;
        GetComponent<TeacherMovement>().enabled = false;

        // go down the screen
        GetComponent<Rigidbody2D>().gravityScale = 3;

        // tell spawn that there is one less enemie
        spawn.EnemieDied();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "BottomOutScene") Destroy(this.gameObject);
    }
}
