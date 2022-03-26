using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    [SerializeField] private float maxX = 7.5f;
    [SerializeField] private float speedMovementOnY = 0.1f;

    private float direction; // moving up or down
    private float UP = 1f, DOWN = -1f;

    private bool xLocked;

    void Start()
    {
        direction = UP;

        xLocked = false;
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        if (!xLocked) MoveHorizontal();
        else MoveVertical();
    }

    void MoveHorizontal() {
        float x = transform.position.x - 0.1f;
        if (x < maxX) {
            xLocked = true;

            // disable movement on x
            GetComponent<FixedObject>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            // activate fire on enemy
            GetComponent<Enemy1Fire>().enabled = true;
        }
    }

    void MoveVertical() {
        transform.position =  transform.position +  new Vector3(0, direction * speedMovementOnY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "TopBorder") direction = DOWN;
        else if (collision.tag == "BottomBorder") direction = UP;
    }
}
