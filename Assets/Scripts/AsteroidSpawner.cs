using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Enemy;
    private float spawnRadius;
    public float startSpawnRadius;
    public float timeBetweenSpawn = 3f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        spawnRadius = startSpawnRadius;
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        SpawnEnemy();
        StartCoroutine(Spawn());

    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = PlayerController.position;
        spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(Enemy, spawnPos, Quaternion.identity);
    }
}

   
