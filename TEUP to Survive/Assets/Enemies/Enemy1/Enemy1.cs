using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] private GameObject shot;
    [SerializeField] private float maxX;

    private float coolDown; // how much to wait for the next shot
    private float nextShot; // instant of the next shot

    private float numShotsCanTake; // number of shots that can take before dies

    private float direction; // moving up or down
    private const float UP = 1f, DOWN = -1f;
    private const float speedMovement = 0.1f;

    void Start()
    {
        coolDown = 2f;
        nextShot = 0f;   

        numShotsCanTake = 1f;

        direction = UP;
    }

    void Update()
    {
        if (CanShot()) {
            Shot();
            nextShot = Time.time + coolDown;
        }
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        if (transform.position.x != maxX) {
            MoveHorizontal();
        }
        else { 
            MoveVertical();
        }
    }

    void MoveHorizontal() {
        float x = transform.position.x - 0.1f;
        if (x < maxX) {
            x = maxX;
        } 

        transform.position =  new Vector3(x, transform.position.y, 0);
    }

    void MoveVertical() {
        transform.position =  transform.position +  new Vector3(0, direction * speedMovement, 0);
    }

    bool CanShot() { // if it is stopped in X and if time has passed
        return transform.position.x == maxX && Time.time > nextShot;
    }

    void Shot() {
        Instantiate(shot, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "TigerShot" && transform.position.x == maxX) {
            numShotsCanTake--;

            if (numShotsCanTake == 0) {
                Destroy(this.gameObject);
            }
        }
        else if (collision.tag == "TopBorder") {
            direction = DOWN;
        }
        else if (collision.tag == "BottomBorder") {
            direction = UP;
        }
    }
}
