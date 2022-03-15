using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameSettings gameSettings;

    private ScoreManager scoreCanvas;
    private float pointsPerEnemy = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];
        scoreCanvas = FindObjectsOfType<ScoreManager>()[0];

        rb.velocity = new Vector2(-gameSettings.scrollSpeed, 0);
    }

    void FixedUpdate() {
        // update movement of shot to go with camera movement
        rb.velocity = new Vector2(rb.velocity.x + gameSettings.speedIncrement, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "RightBorder") Destroy(this.gameObject);

        else if (collision.tag == "Enemy") {
            Destroy(this.gameObject);
            scoreCanvas.score += (int)pointsPerEnemy;
            scoreCanvas.scoreText.text = (int)scoreCanvas.score + "";
        }
    
    }
}
