using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private ScoreManager scoreCanvas;
    private float pointsPerCollectible = 10f;
    private CollectibleMovement collectibleMovement;

    void Start()
    {
        scoreCanvas = FindObjectsOfType<ScoreManager>()[0];
        collectibleMovement = gameObject.GetComponent<CollectibleMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "LeftBorder") {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player") {
            Destroy(this.gameObject);
            scoreCanvas.score += (int)pointsPerCollectible;
            scoreCanvas.scoreText.text = (int)scoreCanvas.score + "";
        }
        else if (collision.tag == "Collectibles Detector"){
            collectibleMovement.enabled = true;
        }
    }
}
