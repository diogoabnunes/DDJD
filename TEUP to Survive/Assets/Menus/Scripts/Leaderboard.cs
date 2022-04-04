using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LeaderboardEntry {
    public string name;
    public int score;
}

public class Leaderboard : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    public List<Transform> highscoreEntryTransformList;
    public int leaderboardHeight = 35;

    private void Awake()
    {
        entryContainer = transform.Find("LeaderboardContainer");
        entryTemplate = entryContainer.Find("LeaderboardEntryTemplate");
    
        entryTemplate.gameObject.SetActive(false);

        // Load highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Sorting by score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    LeaderboardEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (LeaderboardEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(LeaderboardEntry leaderboardEntry, Transform container, List<Transform> transformList) {
        // instantiate leaderboard entry
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -leaderboardHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            default: rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }

        entryTransform.Find("Pos").GetComponent<Text>().text = rankString;
        entryTransform.Find("Name").GetComponent<Text>().text = leaderboardEntry.name.ToString();
        entryTransform.Find("Score").GetComponent<Text>().text = leaderboardEntry.score.ToString();
    
        /*
        switch (rank) {
        default:
            entryTransform.Find("trophy").gameObject.SetActive(false);
            break;
        case 1:
            entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("FFD200");
            break;
        case 2:
            entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("C6C6C6");
            break;
        case 3:
            entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("B76F56");
            break;

        }
        */

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name) {
        // Create LeaderboardEntry
        LeaderboardEntry highscoreEntry = new LeaderboardEntry { score = score, name = name };
    
        // Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to highscores
        if (highscores == null) {
            highscores = new Highscores() {
                highscoreEntryList = new List<LeaderboardEntry>()
            };
        }

        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores {
        public List<LeaderboardEntry> highscoreEntryList;
    }
}
