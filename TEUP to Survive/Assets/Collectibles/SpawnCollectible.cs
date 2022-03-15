using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    [SerializeField] private GameObject collectible;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float timeBetweenCollectibles;
    [SerializeField] private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime) {
            Spawn();
            spawnTime = Time.time + timeBetweenCollectibles;
        }
    }

    void Spawn() {
        float y = Random.Range(minY, maxY);
        Instantiate(collectible, transform.position + new Vector3(0, y, 0), transform.rotation);
    }
}
