using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void TakeShot() {
        FindObjectsOfType<GameSettings>()[0].GetComponent<GameSettings>().GameOver();
    }
}
