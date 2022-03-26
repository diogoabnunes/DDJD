using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : MonoBehaviour
{
    private float duration;
    private float start;

    void Start()
    {
        duration = 20f; // very big value
        start = Time.time;
    }

    void Update()
    {
        if ((Time.time - start) > duration)
            Destroy(this.gameObject);
    } 
}
