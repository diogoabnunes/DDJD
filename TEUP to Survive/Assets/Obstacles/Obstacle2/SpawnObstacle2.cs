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
        Instantiate(obstacle, transform.position + new Vector3(0, Y, 0), transform.rotation);
    }
}
