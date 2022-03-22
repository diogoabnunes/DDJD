using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonFixedObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameSettings gameSettings;

    [SerializeField] private float speed = 4f;
    [SerializeField] private bool directionLeft = false;

    private float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];

        if (directionLeft) direction = -1;
        else direction = 1;

        rb.velocity = new Vector2((Math.Abs(gameSettings.scrollSpeed) + speed) * direction, 0);
    }

    void FixedUpdate() {
        rb.velocity = new Vector2((Math.Abs(gameSettings.scrollSpeed) + speed) * direction, 0);
    }
}
