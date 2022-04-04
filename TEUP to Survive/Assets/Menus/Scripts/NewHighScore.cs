using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewHighScore : MonoBehaviour
{
    [SerializeField] private GameObject nextMenu;
    [SerializeField] private GameObject input;

    new private string name;

    void Start() {
        name = "";
    }

    public void AddHighScore() {
        name = input.GetComponent<Text>().text;

        if (name == "") return;

        SaveHighScore(name);

        // load game over
        SceneManager.LoadScene(2);
    }

    public void SaveHighScore(string name) {
        Debug.Log("Add high score");

        // getActualScore and call Leaderboard.AddHighscoreEntry(actualScore, name)
    }
}
