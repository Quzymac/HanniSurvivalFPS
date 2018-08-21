using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerUI : MonoBehaviour {
    [SerializeField]
    EnemyManager myEnemyManager;

    [SerializeField]
    Text SpawnCounter;

    int SpawnCounterAmount;

    WaveSpawner myWaveSpawner;

	void Start () {
        myWaveSpawner = gameObject.GetComponent<WaveSpawner>();

        SpawnCounterAmount = (myWaveSpawner.GetAmountOfEnemies()) - (myEnemyManager.GetEnemiesKilled());
        SpawnCounter.text = "Enemies left:" + SpawnCounterAmount.ToString();
	}

    public void UpdateWaveSpawnerUI()
    {
        SpawnCounterAmount = (myWaveSpawner.GetAmountOfEnemies()) - (myEnemyManager.GetEnemiesKilled());
        SpawnCounter.text = "Enemies left:" + SpawnCounterAmount.ToString();
    }
}
