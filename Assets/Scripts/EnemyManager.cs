using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField] int enemiesAlive;
    [SerializeField] int enemiesKilled;

    public void EnemyShot(GameObject enemyGameObject, float dmg)
    {
        enemyGameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
    }
    public int GetEnemiesAlive()
    {
        return enemiesAlive;
    }
    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }
}
