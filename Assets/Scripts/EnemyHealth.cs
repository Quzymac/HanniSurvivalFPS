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
    GameObject myWaveSpawner;

    WaveSpawnerUI myWaveSpawnerUI;

    void Start()
    {

        enemyManager = GameObject.Find("EnemyManager");

        myWaveSpawner = GameObject.Find("WaveController");
        myWaveSpawnerUI = myWaveSpawner.GetComponent<WaveSpawnerUI>(); // my god this is ugly

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
        enemyManager.GetComponent<EnemyManager>().DecreaseCurrentEnemies();
        myWaveSpawnerUI.UpdateWaveSpawnerUI();
        Destroy(gameObject);
    }
}
