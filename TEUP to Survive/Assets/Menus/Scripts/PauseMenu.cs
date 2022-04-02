using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameSettings;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        gameSettings.GetComponent<AudioSource>().Play();
    }

    void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        gameSettings.GetComponent<AudioSource>().Pause();
    }

    public void MainMenu() {
        Debug.Log("Main Menu");
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
