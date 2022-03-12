using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowerUps : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float timeBetweenPowerUps;

    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime) {
            Spawn();
            spawnTime = Time.time + timeBetweenPowerUps;
        }
    }

    void Spawn(){
        int randomPowerUp = Random.Range(0,powerUps.Length);
        float y = Random.Range(minY, maxY);
        Instantiate(powerUps[randomPowerUp], transform.position + new Vector3(0, y, 0), transform.rotation);
    }
}
