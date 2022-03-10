using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool unstoppable;// power-up effect (coffee??)
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
       unstoppable = false; 
    }

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
            rb.AddForce(Vector2.up * 7.5f * speed);
            jump = false;
        }
    }
}
