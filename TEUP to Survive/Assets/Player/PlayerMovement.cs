using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private bool jump;

    void Start()
    {
        jump = false; 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) jump = true;
    }

    void FixedUpdate() {
        if (jump) {
            rb.AddForce(Vector2.up * 7.5f * speed);
            jump = false;
        }
    }
}
