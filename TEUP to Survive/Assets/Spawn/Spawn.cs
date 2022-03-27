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

    [SerializeField] private int numTemplatesBetweenEnemies;

    private float nextSpawn;
    private int numEnemiesAllive;
    private int numTemplates;
    private int numTemplatesInScreen;

    private bool reset;
    
    void Start()
    {
        nextSpawn = -1f;
        numEnemiesAllive = 0;
        numTemplates = 0;
        numTemplatesInScreen = 0;

        reset = false;
    }

    void Update()
    {
        if (CanSpawnEnemie()) SpawnEnemie();
        else if (CanSpawnCompleteTemplate()) SpawnCompleteTemplate();
        else if (CanSpawnCoinTemplate()) SpawnCoinTemplate();

        // if (CanSpawn()) SpawnCoinTemplate();
        // if (CanSpawn()) SpawnCompleteTemplate();
    }

    bool CanSpawnEnemie() {
        return CanSpawn() && numTemplates >= numTemplatesBetweenEnemies;
    }

    bool CanSpawnCompleteTemplate() {
        return CanSpawn() && numEnemiesAllive == 0;
    }

    bool CanSpawnCoinTemplate() {
        return CanSpawn() && numEnemiesAllive != 0;
    }

    bool CanSpawn() {
        return Time.time > nextSpawn && numTemplates == numTemplatesInScreen;
    }

    void SpawnEnemie() {
        int enemie = Random.Range(0, enemies.Length);

        Instantiate(enemies[enemie], transform.position, transform.rotation);

        numEnemiesAllive++;
        numTemplates = 0;
        numTemplatesInScreen = 0;
    }

    void SpawnCompleteTemplate() {
        int template = Random.Range(0, completeTemplates.Length);
        // int template = 0;

        // spawn coins
        foreach (GameObject templateCoin in completeTemplates[template].templateCoins) {
            if (generate()) {
                Instantiate(templateCoin, transform.position, transform.rotation);
                
                numTemplates++;
            }
        }

        // spawn obstacles
        foreach (GameObject templateObstacle in completeTemplates[template].templateObstacles) {
            if (generate()) {
                Instantiate(templateObstacle, transform.position, transform.rotation);
                
                numTemplates++;
            }
        }

        // spawn powerups
        foreach (Position position in completeTemplates[template].powerups) {
            if (generate()) {
                int powerup = Random.Range(0, powerups.Length);
                
                Instantiate(powerups[powerup], transform.position + new Vector3(position.x, position.y, 0), transform.rotation);
            }
        }
    }

    void SpawnCoinTemplate() {
        int coin = Random.Range(0, coinTemplates.Length);
        float y = Random.Range(coinTemplates[coin].minY, coinTemplates[coin].maxY);

        Instantiate(coinTemplates[coin].template, new Vector3(transform.position.x, y, 0), coinTemplates[coin].template.transform.rotation);

        numTemplates++;
    }

    bool generate() {
        return Random.Range(0, 2) == 1;
    }

    public void EnemieDied() {
        reset = true;
        numEnemiesAllive--;

        if (numEnemiesAllive < 0) 
            numEnemiesAllive = 0;

        if (Time.time > nextSpawn)
            nextSpawn = Time.time;

        if (CanReset())
            Reset();
    }

    public void TemplateInScreen() {
        if (numTemplatesInScreen < numTemplates)
            numTemplatesInScreen++;

        if (numTemplatesInScreen == numTemplates)
            nextSpawn = Time.time + 2f;

        if (CanReset())
            Reset();

        Debug.Log("Templates In Screen: " + numTemplatesInScreen);
    }

    bool CanReset() {
        return numTemplatesInScreen == numTemplates && reset;
    }

    void Reset() {
        numTemplates = 0;
        numTemplatesInScreen = 0;

        reset = false;
    }
}