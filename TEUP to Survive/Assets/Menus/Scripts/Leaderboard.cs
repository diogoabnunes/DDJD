using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardContainer;
    [SerializeField] private GameObject leaderboardEntryTemplate;

    void Awake()
    {
        LeaderboardManager.LoadLeaderboard();
        ShowLeaderboard();
    }

    void ShowLeaderboard() {
        int leaderboardHeight = 35;
        List<LeaderboardEntry> leaderboard = LeaderboardManager.GetLeaderboard();

        for (int i = 0; i < leaderboard.Count; i++) {            
            // instantiate leaderboard entry
            GameObject entry = Instantiate(leaderboardEntryTemplate, leaderboardContainer.transform);
            RectTransform entryRectTransform = entry.transform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -leaderboardHeight * i);

            // enable entry
            entry.SetActive(true);

            // update leaderboard entry
            entry.transform.Find("Pos").GetComponent<Text>().text = (i + 1).ToString() + ".";
            Debug.Log(leaderboard[i].name.ToString());
            Debug.Log(leaderboard[i].score.ToString());
            entry.transform.Find("Name").GetComponent<Text>().text = leaderboard[i].name.ToString();
            entry.transform.Find("Score").GetComponent<Text>().text = leaderboard[i].score.ToString();
        }
    }
}
