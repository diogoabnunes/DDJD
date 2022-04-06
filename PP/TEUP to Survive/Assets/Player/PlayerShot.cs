using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    private ScoreManager scoreCanvas;
    private float pointsPerEnemy = 50f;

    void Start()
    {
        scoreCanvas = FindObjectsOfType<ScoreManager>()[0];
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
