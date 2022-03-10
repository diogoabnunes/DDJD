using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D backgroundCollider;
    public Rigidbody2D rb;
    private float width;
    private GameSettings gameSettings;

    // Start is called before the first frame update
    void Start()
    {
        backgroundCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];

        width = backgroundCollider.size.x * transform.localScale.x;
        backgroundCollider.enabled = false;

        rb.velocity = new Vector2(gameSettings.scrollSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (-width*1.5)){
            Vector2 resetPosition = new Vector2(width * 3f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
       
        rb.velocity = new Vector2(rb.velocity.x - gameSettings.speedIncrement,0);
    }
}