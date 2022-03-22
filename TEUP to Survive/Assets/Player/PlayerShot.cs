using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameSettings gameSettings;
    private ScoreManager scoreCanvas;
    private float pointsPerEnemy = 50f;

    [SerializeField] private float shotSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];
        scoreCanvas = FindObjectsOfType<ScoreManager>()[0];

        rb.velocity = new Vector2(-gameSettings.scrollSpeed + shotSpeed, 0);
    }

    void FixedUpdate() {
        // update movement of shot to go with camera movement
        rb.velocity = new Vector2(-gameSettings.scrollSpeed + shotSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "RightBorder" || collision.tag == "Obstacle") Destroy(this.gameObject);
        else if (collision.tag == "Enemy") {
            Destroy(this.gameObject);
            
            scoreCanvas.score += (int)pointsPerEnemy;
            scoreCanvas.scoreText.text = (int)scoreCanvas.score + "";
        }
    
    }
}
