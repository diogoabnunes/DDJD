using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collectibleCollider;
    [SerializeField] private Rigidbody2D rb;

    private GameSettings gameSettings;
    private GameObject player;
    private ScoreManager scoreCanvas;
    private float pointsPerCollectible = 10f;

    // Start is called before the first frame update
    void Start()
    {
        collectibleCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        gameSettings = FindObjectsOfType<GameSettings>()[0];
        player = GameObject.FindGameObjectWithTag("Player");
        scoreCanvas = FindObjectsOfType<ScoreManager>()[0];

        rb.velocity = new Vector2(gameSettings.scrollSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(rb.velocity.x - gameSettings.speedIncrement, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "LeftBorder") {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player") {
            Destroy(this.gameObject);
            scoreCanvas.score += (int)pointsPerCollectible;
            scoreCanvas.scoreText.text = (int)scoreCanvas.score + " POINTS!";
        }
    }
}
