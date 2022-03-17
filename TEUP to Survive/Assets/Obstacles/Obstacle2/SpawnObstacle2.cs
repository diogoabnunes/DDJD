using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle2 : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float Y;
    [SerializeField] private float timeBetweenObstacles;
    [SerializeField] private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime) {
            Spawn();
            spawnTime = Time.time + timeBetweenObstacles;
        }
    }

    void Spawn() {
        float scale = Random.Range(1.0f, 4.0f);
        GameObject i = Instantiate(obstacle, transform.position + new Vector3(0, Y + scale/2, 0), transform.rotation);
        Transform t = i.transform.GetChild(0);
        t.localScale = new Vector3(1, scale, 1);
    }
}
