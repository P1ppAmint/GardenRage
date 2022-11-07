using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float minSpawnrate;
    [SerializeField]
    private float maxSpawnrate;
    [SerializeField]
    private GameObject[] enemyReference;
    [SerializeField]
    private GameObject[] spawnerReference;

    private GameObject spawnedEnemy;
    private GameObject spawnLoc;
    

    private int randomIndexEnemy;
    private int randomIndexSpawn;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());        
    }
    IEnumerator SpawnEnemy()
    {
        while (true) { 

            yield return new WaitForSeconds(Random.Range((minSpawnrate != 0 ? 1.0f / minSpawnrate : 0), (maxSpawnrate != 0 ? 1.0f / maxSpawnrate : 0)));
        
            randomIndexEnemy = Random.Range(0, enemyReference.Length);
            randomIndexSpawn = Random.Range(0, spawnerReference.Length);

            spawnedEnemy = Instantiate(enemyReference[randomIndexEnemy]);

            GameManager.AddEnemyToList(spawnedEnemy);


            spawnLoc = spawnerReference[randomIndexSpawn];

            spawnedEnemy.transform.position = spawnLoc.transform.position;


            //should affect the EntityStats.movespeed
            //spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
        
        }

    }

}
