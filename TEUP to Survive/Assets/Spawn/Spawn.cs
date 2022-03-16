using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class SpawnableObjects {
    public GameObject spawnableObject;
    public float generationRate;
    public float minY;
    public float maxY;
}

public class Spawn : MonoBehaviour
{
    [SerializeField] private SpawnableObjects[] obstacles;
    [SerializeField] private SpawnableObjects[] collectibles;
    [SerializeField] private SpawnableObjects[] powerUps;
    [SerializeField] private SpawnableObjects[] enemies;

    private int OBSTACLE = 0, COLLECTIBLE = 1, POWER_UPS = 2, ENEMIE = 3;

    private float nextSpawn;
    
    void Start()
    {
        nextSpawn = 0f;
    }

    void Update()
    {
        if (Time.time > nextSpawn) {
            int selectedObject = Random.Range(0, 4);

            if (selectedObject == OBSTACLE) {
                float y = Random.Range(obstacles[0].minY, obstacles[0].maxY);
                Instantiate(obstacles[0].spawnableObject, transform.position + new Vector3(0, y, 0), transform.rotation);
            }
            else if (selectedObject == COLLECTIBLE) {
                float y = Random.Range(collectibles[0].minY, collectibles[0].maxY);
                Instantiate(collectibles[0].spawnableObject, transform.position + new Vector3(0, y, 0), transform.rotation);
            }
            else if (selectedObject == POWER_UPS) {
                int powerUpSelected = Random.Range(0, powerUps.Length);

                float y = Random.Range(powerUps[powerUpSelected].minY, powerUps[powerUpSelected].maxY);
                Instantiate(powerUps[powerUpSelected].spawnableObject, transform.position + new Vector3(0, y, 0), transform.rotation);
            }
            else {
                int enemySelected = Random.Range(0, enemies.Length);

                float y = Random.Range(enemies[enemySelected].minY, enemies[enemySelected].maxY);
                Instantiate(enemies[enemySelected].spawnableObject, transform.position + new Vector3(0, y, 0), transform.rotation);
            }

            nextSpawn = Time.time + 3f;
        }
    }
}