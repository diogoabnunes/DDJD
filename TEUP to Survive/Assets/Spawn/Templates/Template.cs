using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : MonoBehaviour
{
    private float duration;
    private float start;

    private Spawn spawn;

    void Start()
    {
        duration = 40f; // very big value
        start = Time.time;

        spawn = FindObjectsOfType<Spawn>()[0];
    }

    void Update()
    {
        if ((Time.time - start) > duration)
            Destroy(this.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "InScene"){
            spawn.TemplateInScreen();
        }
    }
}
