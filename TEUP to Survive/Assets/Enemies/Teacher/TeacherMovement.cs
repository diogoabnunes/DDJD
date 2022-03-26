using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherMovement : MonoBehaviour
{
    [SerializeField] private float maxX = 7.5f;
    [SerializeField] private float maxY, minY;
    [SerializeField] private float speedMovementOnY = 0.05f;

    [SerializeField] private Sprite jetPackOff;
    [SerializeField] private Sprite jetPackOn;
    private GameObject teacherTop;
    private GameObject teacherBottom;

    private float direction; // moving up or down
    private float nextUpdateOnY;

    private GameObject player;

    private bool movementLocked;

    void Start()
    {
        nextUpdateOnY = 0f;
        player = GameObject.FindGameObjectWithTag("Player");
        movementLocked = false;

        teacherBottom = this.gameObject.transform.GetChild(0).gameObject;
        teacherTop = this.gameObject.transform.GetChild(1).gameObject;
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
            GetComponent<TeacherFire>().enabled = true;
            GetComponent<Teacher>().enabled = true;
        } 

        transform.position =  new Vector3(x, transform.position.y, 0);
    }

    void MoveVertical() {
        if (Time.time > nextUpdateOnY && !movementLocked) {
            updateDirection();
            
            if (direction != 0) {
                float newY = transform.position.y + direction * speedMovementOnY;
                
                if (newY > maxY) newY = maxY;
                else if (newY < minY) newY = minY;

                transform.position = new Vector3(transform.position.x, newY, 0);
            }
        }
    }

    void updateDirection() {
        if ((player.transform.position.y - transform.position.y) == 0) direction = 0f;
        direction = (player.transform.position.y - transform.position.y) / Mathf.Abs(player.transform.position.y - transform.position.y);
        
        if( (direction >= 0f) || (transform.position.y == minY)){
            teacherBottom.GetComponent<SpriteRenderer>().sprite = jetPackOn;
            teacherTop.GetComponent<SpriteRenderer>().sprite = jetPackOn;
            return;
        }

        teacherBottom.GetComponent<SpriteRenderer>().sprite = jetPackOff;
        teacherTop.GetComponent<SpriteRenderer>().sprite = jetPackOff;
    }

    public void LockMovement() {
        movementLocked = true;
        teacherBottom.GetComponent<SpriteRenderer>().sprite = jetPackOn;
        teacherTop.GetComponent<SpriteRenderer>().sprite = jetPackOn;
    }

    public void UnlockMovement() {
        movementLocked = false;
    }
}
