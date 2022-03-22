using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle1 : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
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

    void Spawn(){
        float y = Random.Range(minY, maxY);
        Instantiate(obstacle, transform.position + new Vector3(0, y, 0), transform.rotation);
    }
}
