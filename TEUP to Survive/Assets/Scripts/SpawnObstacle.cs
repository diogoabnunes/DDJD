using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private float timeBetweenObstacles;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime){
            Spawn();
            spawnTime = Time.time + timeBetweenObstacles;
        }
    }

    void Spawn(){

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(obstacles[0], transform.position + new Vector3(x,y,0), transform.rotation);
        // Instantiate(obstacles[1], transform.position + new Vector2(x,y), transform.rotation);
    }
}
