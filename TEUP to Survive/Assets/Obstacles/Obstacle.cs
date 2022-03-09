using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{   
    public BoxCollider2D obstacleCollider;
    public Rigidbody2D rb;
    private float width;
    private GameSettings gameSettings;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        obstacleCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];
       
        width = obstacleCollider.size.x * transform.localScale.x;
        rb.velocity = new Vector2(gameSettings.scrollSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x - gameSettings.speedIncrement,0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Border"){
            Destroy(this.gameObject);
        }
    }
}
