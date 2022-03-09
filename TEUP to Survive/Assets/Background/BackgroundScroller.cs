using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    private float speedIncrement = 0.0001f;
    private float scrollSpeed = -2f;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        width = collider.size.x * transform.localScale.x;
        collider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (-width*1.5)){
            Vector2 resetPosition = new Vector2(width * 3f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
       
        rb.velocity = new Vector2(rb.velocity.x - speedIncrement,0);
    }
}