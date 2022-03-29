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
}

[System.Serializable] public class CollectibleTemplate {
    public GameObject template;

    public float minY;
    public float maxY;
}

public class Spawn : MonoBehaviour
{
    [SerializeField] private CompleteTemplate[] completeTemplates;      // completeTemplates
    [SerializeField] private CollectibleTemplate[] coinTemplates;       // coinTemplates
    [SerializeField] private CollectibleTemplate[] powerupTemplates;    // coinTemplates
    [SerializeField] private GameObject[] enemies;                      // enemies

    [SerializeField] private int numTemplatesBetweenEnemies;
    [SerializeField] private float PROBABILITY_OF_COIN_WITH_ENEMIES;

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
        else if (CanSpawnCollectibleTemplate()) SpawnCollectibleTemplate();
    }

    bool CanSpawnEnemie() {
        return CanSpawn() 
            && numTemplates >= numTemplatesBetweenEnemies
            && !AreEnemiesAllive();
    }

    bool CanSpawnCompleteTemplate() {
        return CanSpawn() && !AreEnemiesAllive();
    }

    bool CanSpawnCollectibleTemplate() {
        return CanSpawn() && AreEnemiesAllive();
    }

    bool CanSpawn() {
        return Time.time > nextSpawn && numTemplates == numTemplatesInScreen;
    }

    bool AreEnemiesAllive() {
        return numEnemiesAllive != 0;
    }

    // --------------------------------------------------------------------------------------------------------------------

    void SpawnEnemie() {
        int enemie = Random.Range(0, enemies.Length);

        Instantiate(enemies[enemie], transform.position, transform.rotation);

        numEnemiesAllive++;
    }

    // --------------------------------------------------------------------------------------------------------------------

    void SpawnCompleteTemplate() {
        // choose one template
        int template = Random.Range(0, completeTemplates.Length);

        bool generatedTemplate = false;

        // spawn coins
        foreach (GameObject templateCoin in completeTemplates[template].templateCoins) {
            if (generate()) { 
                generateTemplate(templateCoin, transform.position, transform.rotation);
                generatedTemplate = true;
            }
        }

        // spawn obstacles
        foreach (GameObject templateObstacle in completeTemplates[template].templateObstacles) {
            if (generate()) {
                generateTemplate(templateObstacle, transform.position, transform.rotation);
                generatedTemplate = true;
            }
        }

        // spawn powerups
        foreach (Position position in completeTemplates[template].powerups) {
            if (generate() && generatedTemplate) 
                generatePowerUp(true, 
                                transform.position + new Vector3(position.x, position.y, 0),
                                transform.rotation);
        }
    }

    // --------------------------------------------------------------------------------------------------------------------

    void SpawnCollectibleTemplate() {
        if (Random.Range(0.0f, 1.0f) > PROBABILITY_OF_COIN_WITH_ENEMIES) SpawnPowerUp();
        else SpawnCoinTemplate();
    }

    void SpawnCoinTemplate() {
        int coin = Random.Range(0, coinTemplates.Length);
        float y = Random.Range(coinTemplates[coin].minY, coinTemplates[coin].maxY);

        generateTemplate(coinTemplates[coin].template, 
                        new Vector3(transform.position.x, y, 0), 
                        coinTemplates[coin].template.transform.rotation);
    }

    void SpawnPowerUp() {
        generatePowerUp(false, Vector3.zero, transform.rotation);

        nextSpawn = Time.time + 5f;
    }

    // --------------------------------------------------------------------------------------------------------------------

    bool generate() {
        return Random.Range(0, 2) == 1;
    }

    void generateTemplate(GameObject template, Vector3 position, Quaternion rotation) {
        Instantiate(template, position, rotation);

        numTemplates++;
    }

    void generatePowerUp(bool defined, Vector3 position, Quaternion rotation) {
        int powerup = Random.Range(0, powerupTemplates.Length);

        if (!defined) {
            float y = Random.Range(powerupTemplates[powerup].minY, powerupTemplates[powerup].maxY);
            position = new Vector3(transform.position.x, y, 0);
            rotation = powerupTemplates[powerup].template.transform.rotation;
        }

        Instantiate(powerupTemplates[powerup].template, position, rotation);
    }

    // ------------------------------------------------------------------------------------------------

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