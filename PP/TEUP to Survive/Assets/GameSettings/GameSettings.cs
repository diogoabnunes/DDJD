using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public float scrollSpeed; // current game speed
    public float speedIncrement; // game increment after some time

    void Update() {
        // MAYBE JUST UPDATE AFTER EVERY 10 SECONDS ???
        scrollSpeed -= speedIncrement;
    }

    public void GameOver() {
        int score = (int) FindObjectsOfType<ScoreManager>()[0].score;

        // load new high score menu
        if (LeaderboardManager.IsNewHighScore(score)) {
            LeaderboardManager.newHighscore = score;
            SceneManager.LoadScene(3);
        }
        // load game over menu
        else {
            SceneManager.LoadScene(2);
        }
    }
}
