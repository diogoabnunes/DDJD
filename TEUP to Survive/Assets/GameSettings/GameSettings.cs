using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public float scrollSpeed = -2f;
    public float speedIncrement = 0.0001f;

    void FixedUpdate() {
        scrollSpeed -= speedIncrement;
    }
}
