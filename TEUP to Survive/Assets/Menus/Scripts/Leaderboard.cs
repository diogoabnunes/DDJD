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
    private LeaderboardEntry[] leaderboardEntries;

    [SerializeField] private GameObject leaderboardContainer;
    [SerializeField] private GameObject leaderboardEntryTemplate;

    void Start()
    {
        leaderboardEntries = new LeaderboardEntry[5];

        LoadLeaderboard();
        ShowLeaderboard();
    }

    void LoadLeaderboard() {
        // dummy code
        for (int i = 0; i < 5; i++) {
            LeaderboardEntry entry = new LeaderboardEntry();
            entry.position = i + 1;
            entry.name = "jonny" + i.ToString();
            entry.score = 99999 + i;

            leaderboardEntries[i] = entry;
        }
        // read from file....
    }

    void ShowLeaderboard() {
        int leaderboardHeight = 35;

        for (int i = 0; i < 5; i++) {
            // instantiate leaderboard entry
            GameObject entry = Instantiate(leaderboardEntryTemplate, leaderboardContainer.transform);
            RectTransform entryRectTransform = entry.transform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -leaderboardHeight * i);

            // enable entry
            entry.SetActive(true);

            // update leaderboard entry
            entry.transform.Find("Pos").GetComponent<Text>().text = leaderboardEntries[i].position.ToString() + ".";
            entry.transform.Find("Name").GetComponent<Text>().text = leaderboardEntries[i].name.ToString();
            entry.transform.Find("Score").GetComponent<Text>().text = leaderboardEntries[i].score.ToString();
        }
    }
}
