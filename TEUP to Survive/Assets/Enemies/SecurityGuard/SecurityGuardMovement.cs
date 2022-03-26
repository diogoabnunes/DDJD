using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGuardMovement : MonoBehaviour
{
    [SerializeField] private float maxX = 7.5f;
    [SerializeField] private float speedMovementOnY = 0.1f;
    
    [SerializeField] private Sprite jetPackOff;
    [SerializeField] private Sprite jetPackOn;
    private GameObject securityGuard;

    private float direction; // moving up or down
    private float UP = 1f, DOWN = -1f;

    void Start()
    {
        direction = UP;
        securityGuard = this.gameObject.transform.GetChild(0).gameObject;
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
            GetComponent<SecurityGuardFire>().enabled = true;
        } 

        transform.position =  new Vector3(x, transform.position.y, 0);
    }

    void MoveVertical() {
        transform.position =  transform.position +  new Vector3(0, direction * speedMovementOnY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "TopBorder"){ 
            direction = DOWN;
            securityGuard.GetComponent<SpriteRenderer>().sprite = jetPackOff;
        }
        else if (collision.tag == "BottomBorder"){ 
            direction = UP;
            securityGuard.GetComponent<SpriteRenderer>().sprite = jetPackOn;
        }
    }
}
