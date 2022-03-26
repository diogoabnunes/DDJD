using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Position {
    public float x;
    public float y;
}

[System.Serializable] public class CompleteTemplate {
    public GameObject[] templateCoins;
    public GameObject[] templateObstacles;
    public Position[] powerups;

    public float duration; // duration of template
}

[System.Serializable] public class CoinTemplate {
    public GameObject template;

    public float minY;
    public float maxY;

    public float duration; // duration of template
}

public class Spawn : MonoBehaviour
{
    [SerializeField] private CompleteTemplate[] completeTemplates;      // completeTemplates
    [SerializeField] private CoinTemplate[] coinTemplates;              // coinTemplates
    [SerializeField] private GameObject[] powerups;                     // powerups
    [SerializeField] private GameObject[] enemies;                      // enemies

    private float nextSpawn;
    private int numCompleteTemplates;
    private int numEnemiesAllive;
    
    void Start()
    {
        nextSpawn = -1f;
        numEnemiesAllive = 0;
        numCompleteTemplates = 0;
    }

    void Update()
    {
        if (CanSpawnEnemie()) SpawnEnemie();
        else if (CanSpawnCompleteTemplate()) SpawnCompleteTemplate();
        else if (CanSpawnCoinTemplate()) SpawnCoinTemplate();
    }

    bool CanSpawnEnemie() {
        return Time.time > nextSpawn && (numCompleteTemplates + 1) % 4 == 0;
    }

    bool CanSpawnCompleteTemplate() {
        return Time.time > nextSpawn && numEnemiesAllive == 0;
    }

    bool CanSpawnCoinTemplate() {
        return Time.time > nextSpawn && numEnemiesAllive != 0;
    }

    void SpawnEnemie() {
        int enemie = Random.Range(0, enemies.Length);

        Instantiate(enemies[enemie], transform.position, transform.rotation);

        numEnemiesAllive++;
        numCompleteTemplates = 0;
        nextSpawn = Time.time + 3f;
    }

    void SpawnCompleteTemplate() {
        int template = Random.Range(0, completeTemplates.Length);

        // spawn coins
        foreach (GameObject templateCoin in completeTemplates[template].templateCoins)
            Instantiate(templateCoin, transform.position, transform.rotation);

        // spawn obstacles
        foreach (GameObject templateObstacle in completeTemplates[template].templateObstacles)
            Instantiate(templateObstacle, transform.position, transform.rotation);

        // spawn powerups
        foreach (Position position in completeTemplates[template].powerups) {
            int powerup = Random.Range(0, powerups.Length);
            
            Instantiate(powerups[powerup], transform.position + new Vector3(position.x, position.y, 0), transform.rotation);
        }
        
        numCompleteTemplates++;
        nextSpawn = Time.time + completeTemplates[template].duration;
    }

    void SpawnCoinTemplate() {
        int coin = Random.Range(0, coinTemplates.Length);
        float y = Random.Range(coinTemplates[coin].minY, coinTemplates[coin].maxY);

        Instantiate(coinTemplates[coin].template, new Vector3(transform.position.x, y, 0), coinTemplates[coin].template.transform.rotation);

        nextSpawn = Time.time + coinTemplates[coin].duration;
    }

    public void EnemieDied() {
        numEnemiesAllive--;

        if (numEnemiesAllive < 0) numEnemiesAllive = 0;
    }
}