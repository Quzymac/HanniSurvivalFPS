using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [SerializeField]
    bool isTriggered;
    [SerializeField]
    EnemyManager enemyManager;
    [SerializeField]
    float timeBetweenSpawns = 3f;

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject[] myEnemies;

    WaveSpawnerUI myWaveSpawnerUI;

    [SerializeField]
    int amountSpawnedEnemies = 5;


    private void Start()
    {
        isTriggered = false;
        myWaveSpawnerUI = gameObject.GetComponent<WaveSpawnerUI>();
    }

    void OnTriggerEnter(Collider col) // When our player enters the platform (trigger)
    {
        if (col.tag == "Player")
        {
            if (isTriggered == false)
            {
                StartCoroutine (Spawn());
            }
                isTriggered = true;          
        }
    }

    IEnumerator Spawn()
    {
        myWaveSpawnerUI.UpdateWaveSpawnerUI();

        for (int i = 0; i < amountSpawnedEnemies; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(myEnemies[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemyManager.IncreaseCurrentEnemies();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void CheckIfFinished(/*int enemiesLeft*/)
    {
        if (enemyManager.GetEnemiesKilled() == amountSpawnedEnemies)
        {
            Debug.Log("A winner is you!");
            // Add some kind of "next level" shit here
        }
        else
            Debug.Log("You ain't done yet, son!");

    }

    public int GetAmountOfEnemies()
    {
        return amountSpawnedEnemies;
    }
}
