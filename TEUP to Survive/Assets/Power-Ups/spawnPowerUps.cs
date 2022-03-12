using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPowerUps : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;
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
        float y = Random.Range(minY, maxY);
        Instantiate(powerUp, transform.position + new Vector3(0, y, 0), transform.rotation);
    }
}
