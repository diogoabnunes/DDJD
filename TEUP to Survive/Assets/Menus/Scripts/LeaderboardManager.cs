using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class LeaderboardManager
{
    // leaderboard with 5 entries
    private static List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

    // value to be defined if a new highscore was achieved
    public static int newHighscore = -1;

    private static bool IsLoaded() {
        return leaderboard.Count > 0;
    }

    private static void CreateFileIfNeeded() {
        if(!System.IO.File.Exists(System.IO.Path.Combine(Application.persistentDataPath + "/Leaderboard.txt")))
            System.IO.File.Create(System.IO.Path.Combine(Application.persistentDataPath + "/Leaderboard.txt"));
    }
    
    public static void LoadLeaderboard() {
        CreateFileIfNeeded();

        // verify if it was already loaded
        if (IsLoaded()) return;

        // read info from file
        string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(Application.persistentDataPath + "/Leaderboard.txt"));
        foreach (string line in lines) {
            string[] content = line.Split(',');
            leaderboard.Add(new LeaderboardEntry(content[0], Int32.Parse(content[1])));
        }
    }

    public static void SaveLeaderboard() {
        // write info into file
        List<string> content = new List<string>();
        foreach (LeaderboardEntry entry in leaderboard) {
            string line = entry.name + ',' + entry.score.ToString();
            content.Add(line);
        }

        System.IO.File.WriteAllLines(System.IO.Path.Combine(Application.persistentDataPath + "/Leaderboard.txt"), content);
    }

    public static List<LeaderboardEntry> GetLeaderboard() {
        return leaderboard;
    }
    
    public static bool IsNewHighScore(int newScore) {        
        LoadLeaderboard();
        return leaderboard.Count < 5 || newScore > leaderboard[leaderboard.Count - 1].score;
    }

    public static void AddNewHighScore(string name) {
        // add to leaderboard
        leaderboard.Add(new LeaderboardEntry(name, newHighscore));
        
        // sort leaderboard
        leaderboard.Sort((x, y) => y.score.CompareTo(x.score));

        // remove extra elements
        while (leaderboard.Count > 5)
            leaderboard.RemoveAt(5);

        // write to file
        SaveLeaderboard();

        // reset newHighscore
        newHighscore = -1;
    }
}
