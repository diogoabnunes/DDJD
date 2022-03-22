using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    * Apos gerar X obstaculos gera um inimigo aleatorio.
*/

[System.Serializable] public class SpawnableObjects {
    public GameObject spawnableObject;
    public float generationRate;
    public float minY;
    public float maxY;
}

public class Spawn : MonoBehaviour
{
    // Objects to spawn
    [SerializeField] private SpawnableObjects[] obstacles;
    [SerializeField] private SpawnableObjects[] collectibles;
    [SerializeField] private SpawnableObjects[] powerUps;
    [SerializeField] private SpawnableObjects[] enemies;

    // Logic of spawning
    [SerializeField] private int numObstaclesBetweenEnemies;
    [SerializeField] private int numCollectiblesBetweenPowerUps;

    private bool spawnObstacle;
    private bool spawnCollectible;
    
    private int currObstaclesBetweenEnemies;
    private int currCollectiblesBetweenPowerUps;

    private int numEnemiesLive;

    private float nextSpawn;
    
    void Start()
    {
        nextSpawn = 0f;

        currObstaclesBetweenEnemies = 0;
        currCollectiblesBetweenPowerUps = 0;

        spawnObstacle = true;
        spawnCollectible = true;

        numEnemiesLive = 0;
    }

    void Update()
    {
        if (CanSpawn()) {
            int spawnable = Random.Range(0, 2);
            
            if (spawnable == 0) { // spawn an obstacle or an enemy
                if (spawnObstacle) SpawnObstacle();
                else SpawnEnemie();
            }
            else { // spawn a collectible or powerup
                if (spawnCollectible) SpawnCollectible();
                else SpawnPowerUp();
            }
        }
    }

    /**
        There can't be any enemy on scene, and spawnTime must be reached.
    */
    bool CanSpawn() {
        return Time.time > nextSpawn && numEnemiesLive == 0;
    }

    void SpawnObject(GameObject spawnableObject, float minY, float maxY) {
        float y = Random.Range(minY, maxY);
        Instantiate(spawnableObject, transform.position + new Vector3(0, y, 0), transform.rotation);
    }

    void SpawnObstacle2(GameObject obstacle2, float Y) {
        float scale = Random.Range(1.0f, 4.0f);
        GameObject i = Instantiate(obstacle2, transform.position + new Vector3(0, Y + scale/2, 0), transform.rotation);
        Transform t = i.transform.GetChild(0);
        t.localScale = new Vector3(1, scale, 1);
    }

    void SpawnCollectible() {
        SpawnObject(collectibles[0].spawnableObject, collectibles[0].minY, collectibles[0].maxY);

        currCollectiblesBetweenPowerUps++;
        if (currCollectiblesBetweenPowerUps % numCollectiblesBetweenPowerUps == 0) {
            spawnCollectible = false;
            currCollectiblesBetweenPowerUps = 0; // reset counting
        }

        nextSpawn = Time.time + collectibles[0].generationRate;
    }

    void SpawnPowerUp() {
        int powerUpSelected = Random.Range(0, powerUps.Length);
        SpawnObject(powerUps[powerUpSelected].spawnableObject, powerUps[powerUpSelected].minY, powerUps[powerUpSelected].maxY);
        
        spawnCollectible = true;

        nextSpawn = Time.time + powerUps[powerUpSelected].generationRate;
    }

    void SpawnObstacle() {
        int obstacleSelected = Random.Range(0, obstacles.Length);
        if (obstacleSelected == 0) {
            SpawnObject(obstacles[obstacleSelected].spawnableObject, obstacles[obstacleSelected].minY, obstacles[obstacleSelected].maxY);
        }
        else {
            SpawnObstacle2(obstacles[obstacleSelected].spawnableObject, obstacles[obstacleSelected].minY);
        }

        currObstaclesBetweenEnemies++;
        if (currObstaclesBetweenEnemies % numObstaclesBetweenEnemies == 0) {
            spawnObstacle = false;
            currObstaclesBetweenEnemies = 0; // reset counting
        }

        nextSpawn = Time.time + obstacles[0].generationRate;
    }

    void SpawnEnemie() {
        int enemySelected = Random.Range(0, enemies.Length);
        SpawnObject(enemies[enemySelected].spawnableObject, enemies[enemySelected].minY, enemies[enemySelected].maxY);

        numEnemiesLive++;
        
        nextSpawn = Time.time + enemies[enemySelected].generationRate;
    }

    public void EnemieDied() {
        numEnemiesLive--;

        if (numEnemiesLive == 0) spawnObstacle = true;
    }
}