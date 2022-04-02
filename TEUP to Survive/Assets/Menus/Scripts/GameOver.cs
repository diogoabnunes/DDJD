using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene(1);
    }
    
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
