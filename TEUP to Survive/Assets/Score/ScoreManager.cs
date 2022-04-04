using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public float score;
    public float pointsPerSecond = 2f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        PlayerPrefs.SetString("score", (int)score + "");
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (int)score + "";
        score += pointsPerSecond * Time.deltaTime;
        PlayerPrefs.SetString("score", (int)score + "");
        PlayerPrefs.Save();
    }

    public void AddPoints(int points)
    {
        score += (int)points;
        scoreText.text = (int)score + "";
        PlayerPrefs.SetString("score", (int)score + "");
        PlayerPrefs.Save();
    }
}
