using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    float enemyMaxHP = 100f;
    [SerializeField]
    float enemyCurrentHP;
    [SerializeField]
    Slider enemyHPSlider;
    [SerializeField]
    GameObject enemyManager;
    [SerializeField]
    WaveSpawner myWaveSpawner;

    void Start()
    {

        enemyManager = GameObject.Find("EnemyManager");


        enemyCurrentHP = enemyMaxHP;

        enemyHPSlider.maxValue = enemyMaxHP;
        enemyHPSlider.minValue = 0f;
        enemyHPSlider.value = enemyCurrentHP;
    }

    private void Update()
    {
        enemyHPSlider.transform.rotation = Camera.main.transform.rotation;
    }

    public void TakeDamage(float dmg)
    {
        enemyCurrentHP -= dmg;
        enemyHPSlider.value = enemyCurrentHP;
        if (enemyCurrentHP < 1f)
        {
            EnemyDie();
        }
    }
    void EnemyDie()
    {
        enemyManager.GetComponent<EnemyManager>().DecreaseCurrentEnemies(gameObject);
           /*DecreaseCurrentEnemies(gameObject);   /*I really want this to work*/
        Destroy(gameObject);
    }

    /*
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")  // Change this how you want so that it fits your code :)
        {
            enemyCurrentHP -= 20f;
            Destroy(col.gameObject);
            enemyHPSlider.value = enemyCurrentHP;
            if (enemyCurrentHP < 1f)
            {
                Destroy(gameObject);
            }
        }
    }
    */
}
