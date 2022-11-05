using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
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

            yield return new WaitForSeconds(Random.Range(1, 5));
        
            randomIndexEnemy = Random.Range(0, enemyReference.Length);
            randomIndexSpawn = Random.Range(0, spawnerReference.Length);

            spawnedEnemy = Instantiate(enemyReference[randomIndexEnemy]);
            spawnLoc = spawnerReference[randomIndexSpawn];

            spawnedEnemy.transform.position = spawnLoc.transform.position;
            spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
        
        }

    }

}
