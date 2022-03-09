using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private bool jump = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
    }

    void FixedUpdate() {
        if (jump) {
            rb.AddForce(Vector2.up * 1.2f * speed, ForceMode2D.Impulse);
            jump = false;
        }
    }
}
