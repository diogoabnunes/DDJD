using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameSettings gameSettings;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];

        rb.velocity = new Vector2(gameSettings.scrollSpeed, 0);
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(gameSettings.scrollSpeed, 0);
    }
}
