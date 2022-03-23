using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private bool jump;
    private PlayerMovementSound playerMovementSound;

    void Start()
    {
        jump = false;
        playerMovementSound = FindObjectsOfType<PlayerMovementSound>()[0];
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            playerMovementSound.On();
            jump = true;
        }
        else {
            playerMovementSound.Off();
        }
    }

    void FixedUpdate() {
        if (jump) {
            rb.AddForce(Vector2.up * 7.5f * speed);
            jump = false;
        }
    }
}
