using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    //[SerializeField] int enemiesAlive;
    [SerializeField] int enemiesKilled;
    [SerializeField]
    WaveSpawner waveSpawner;
    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();  // Thought this might be used to keep track of how many are left (0 unlocks next level?) instead of an int which increases/decreases.

    public void EnemyShot(GameObject enemyGameObject, float dmg)
    {
        enemyGameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
    }

    /*public int GetEnemiesAlive()
    {
        return enemiesAlive;
    }*/

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }

    public int GetCurrentAmountOfEnemies()
    {
        return enemies.Count; 
    }

    public void IncreaseCurrentEnemies(GameObject spawnedEnemy)
    {
        enemies.Add(spawnedEnemy);
        //enemiesAlive++;
        return;
    }

    public void DecreaseCurrentEnemies(GameObject killedEnemy)
    {
        enemies.Remove(killedEnemy);
        enemiesKilled++;
        waveSpawner.CheckIfFinished(enemies.Count - 1); // I guess?
        //enemiesAlive--;
        return;
    }
}
