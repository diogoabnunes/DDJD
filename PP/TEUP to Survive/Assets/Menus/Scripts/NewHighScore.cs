using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewHighScore : MonoBehaviour
{
    [SerializeField] private GameObject input;
    [SerializeField] private GameObject score;

    new private string name;

    void Start() {
        // set score in screen
        score.GetComponent<Text>().text = LeaderboardManager.newHighscore.ToString();

        name = "";
    }

    public void AddHighScore() {
        name = input.GetComponent<Text>().text;

        if (name == "") return;

        SaveHighScore();

        // load game over
        SceneManager.LoadScene(2);
    }

    public void SaveHighScore() {
        LeaderboardManager.AddNewHighScore(name);
    }
}
