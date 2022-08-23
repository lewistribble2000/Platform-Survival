using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;

    private int enemyCount;
    private int waves;

    public Vector2 spawnRange;

    private void Start()
    {
        waves = 1;
        //spawnEnemy();
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if(enemyCount == 0)
        {
            waves++;
            //spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        for(int i = 0; i < waves; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnRange[0], spawnRange[1]),
                enemyPrefab.transform.position.y,
                Random.Range(spawnRange[0], spawnRange[1]));
            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        }   
    }
}
