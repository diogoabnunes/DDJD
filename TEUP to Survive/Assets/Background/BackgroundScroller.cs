using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private BoxCollider2D backgroundCollider;
    [SerializeField] private Rigidbody2D rb;

    private float width;
    private GameSettings gameSettings;

    void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];

        width = backgroundCollider.size.x * transform.localScale.x;
        backgroundCollider.enabled = false;

        rb.velocity = new Vector2(gameSettings.scrollSpeed, 0);
    }

    void FixedUpdate()
    {
        if (transform.position.x < (-width * 1.5)){
            Vector2 resetPosition = new Vector2(width * 3f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
       
        rb.velocity = new Vector2(gameSettings.scrollSpeed, 0);
    }
}