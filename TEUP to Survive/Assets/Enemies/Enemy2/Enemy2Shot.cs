using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Shot : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameSettings gameSettings;

    [SerializeField] private float shotSpeed = -4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];

        rb.velocity = new Vector2(gameSettings.scrollSpeed + shotSpeed, 0);
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        // update movement of shot to go with camera movement
        rb.velocity = new Vector2(gameSettings.scrollSpeed + shotSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "LeftBorder" || collision.tag == "Obstacle") Destroy(this.gameObject);
        else if (collision.tag == "Player") collision.GetComponent<Player>().TakeShot();
    }
}
