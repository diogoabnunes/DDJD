using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float numShotsCanTake = 1f; // number of shots that can
    private float numShotsTaken;

    public Spawn spawn;

    void Start() {
        numShotsTaken = 0f;

        spawn = FindObjectsOfType<Spawn>()[0];
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "TigerShot") TakeShot(collision.gameObject);
        else if(collision.tag == "BottomOutScene") Destroy(this.gameObject);
    }

    void TakeShot(GameObject tigerShot) {
        if (GetComponent<Enemy1Fire>().enabled) { // is firing
            numShotsTaken += 1f;

            // destroy tiger shot
            Destroy(tigerShot);

            if (numShotsTaken == numShotsCanTake) Die();
        }
    }

    void Die() {
        // disable shots and movement
        GetComponent<Enemy1Fire>().enabled = false;
        GetComponent<Enemy1Movement>().enabled = false;

        // go down the screen
        GetComponent<Rigidbody2D>().gravityScale = 3f;

        // tell spawn that there is one less enemie
        spawn.EnemieDied();
    }
}
