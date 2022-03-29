using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public float scrollSpeed; // current game speed
    public float speedIncrement; // game increment after some time

    void Update() {
        // MAYBE JUST UPDATE AFTER EVERY 10 SECONDS ???
        scrollSpeed -= speedIncrement;
    }
}
