using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    //[SerializeField] int enemiesAlive;
    [SerializeField]
    int enemiesKilled;
    [SerializeField]
    int enemiesAlive;

    [SerializeField]
    WaveSpawner waveSpawner;
    //List<GameObject> currentEnemiesAlive = new List<GameObject>();  Thought this might be used to keep track of how many are left (0 unlocks next level?) instead of an int which increases/decreases.    

    private void Start()
    {
        enemiesKilled = 0;
    }

    public void EnemyShot(GameObject enemyGameObject, float dmg)
    {
        enemyGameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
    }

    public void IncreaseCurrentEnemies()
    {
        enemiesAlive++;
        return;
    }

    public void DecreaseCurrentEnemies()
    {
        // currentEnemiesAlive.Remove(killedEnemy); 
        enemiesAlive--;
        enemiesKilled++;
        waveSpawner.CheckIfFinished();
        return;
    }

    public int GetEnemiesAlive()
    {
        return enemiesAlive;
    }

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }

    public void ResetEnemiesDead()
    {
        enemiesKilled = 0;
        return;
    }
}
