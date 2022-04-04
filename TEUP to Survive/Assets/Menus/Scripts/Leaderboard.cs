using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class LeaderboardEntry {
    public int position;
    public string name;
    public int score;
}

public class Leaderboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<LeaderboardEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private int leaderboardHeight = 35;

    private void Awake()
    {
        entryContainer = transform.Find("LeaderboardContainer");
        entryTemplate = entryContainer.Find("LeaderboardEntryTemplate");
    
        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<LeaderboardEntry>() {
            new LeaderboardEntry{ position = 1, name = "Diogo1", score = 123 },
            new LeaderboardEntry{ position = 1, name = "Diogo2", score = 121 },
            new LeaderboardEntry{ position = 1, name = "Diogo3", score = 99 },
            new LeaderboardEntry{ position = 1, name = "Diogo4", score = 10 },
            new LeaderboardEntry{ position = 1, name = "Diogo5", score = 1 },
        };

        highscoreEntryTransformList = new List<Transform>();
        foreach (LeaderboardEntry highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(LeaderboardEntry leaderboardEntry, Transform container, List<Transform> transformList) {
        // instantiate leaderboard entry
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -leaderboardHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        // update leaderboard entry
        entryTransform.Find("Pos").GetComponent<Text>().text = leaderboardEntry.position.ToString() + ".";
        entryTransform.Find("Name").GetComponent<Text>().text = leaderboardEntry.name.ToString();
        entryTransform.Find("Score").GetComponent<Text>().text = leaderboardEntry.score.ToString();
    
        transformList.Add(entryTransform);
    }
}
