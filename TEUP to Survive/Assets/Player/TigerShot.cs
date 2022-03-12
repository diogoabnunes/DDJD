using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerShot : MonoBehaviour
{

    private Rigidbody2D rb;
    private GameSettings gameSettings;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];

        rb.velocity = new Vector2(-gameSettings.scrollSpeed, 0);
    }

    void FixedUpdate() {
        // update movement of shot to go with camera movement
        rb.velocity = new Vector2(rb.velocity.x + gameSettings.speedIncrement, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "RightBorder"){
            Debug.Log("Destroy object");
            Destroy(this.gameObject);
        }
    }
}