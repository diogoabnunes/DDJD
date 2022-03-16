using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    [SerializeField] private float maxX = 7.5f;
    [SerializeField] private float maxY = 3.1f, minY = -0.4f;
    [SerializeField] private float speedMovementOnY = 0.05f;

    private float direction; // moving up or down
    private float nextUpdateOnY;

    private GameObject player;

    private bool movementLocked;

    void Start()
    {
        nextUpdateOnY = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
        movementLocked = false;
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        if (transform.position.x != maxX) MoveHorizontal();
        else MoveVertical();
    }

    void MoveHorizontal() {
        float x = transform.position.x - 0.1f;
        if (x < maxX) {
            x = maxX;

            // activate fire on enemy
            GetComponent<Enemy2Fire>().enabled = true;
            GetComponent<Enemy2>().enabled = true;
        } 

        transform.position =  new Vector3(x, transform.position.y, 0);
    }

    void MoveVertical() {
        if (Time.time > nextUpdateOnY && !movementLocked) {
            updateDirection();
            
            if (direction != 0) {
                float newY = transform.position.y + direction * speedMovementOnY;
                // Debug.Log(transform.position.y);
                if (newY > maxY) newY = maxY;
                else if (newY < minY) newY = minY;

                transform.position = new Vector3(transform.position.x, newY, 0);
            }

            // nextUpdateOnY = Time.time + 0.1f;
        }
    }

    void updateDirection() {
        if ((player.transform.position.y - transform.position.y) == 0) direction = 0f;
        direction = (player.transform.position.y - transform.position.y) / Mathf.Abs(player.transform.position.y - transform.position.y);
    }

    public void LockMovement() {
        movementLocked = true;
    }

    public void UnlockMovement() {
        movementLocked = false;
    }
}
