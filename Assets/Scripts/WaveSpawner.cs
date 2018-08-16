using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [SerializeField]
    bool isTriggered;
    [SerializeField]
    EnemyManager EnemyManager;

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject[] myEnemies;

    

    int amountOfEnemies = 5;
    //float timeBetweenSpawns = 3f;

    private void Start()
    {
        isTriggered = false;
    }

    void OnTriggerEnter(Collider col) // When our player enters the platform (trigger)
    {
        if (col.tag == "Player")
        {
            if (isTriggered == false)
            {
                Spawn();
            }
                isTriggered = true;          
        }
    }

    void Spawn()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length); // Gets a random spawnpoint! :)
            Instantiate(myEnemies[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            EnemyManager.IncreaseCurrentEnemies(myEnemies[0]);
        }
    }

    public void CheckIfFinished(int enemiesLeft)
    {
        if (enemiesLeft == 0)
        {
            Debug.Log("A winner is you!");
        }
        else
            Debug.Log("The code reached this???");

    }
}
