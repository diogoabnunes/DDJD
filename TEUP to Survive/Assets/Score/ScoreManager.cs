using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;

    public float score;
    public float pointsPerSecond = 1f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        score += pointsPerSecond * Time.deltaTime;
        scoreText.text = (int)score + "";
    }

    public void AddPoints(int points)
    {
        score += (int)points;
        scoreText.text = (int)score + "";
    }
}
