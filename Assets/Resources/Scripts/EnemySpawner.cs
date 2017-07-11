using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{

    public GameObject enemyPrefab;
    public float spawnFrequencyInSecs;
    public float spawnDistance;

    public override void OnStartServer()
    {
        base.OnStartServer();

        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float randX = UnityEngine.Random.Range(-spawnDistance, spawnDistance);
            float randY = UnityEngine.Random.Range(-spawnDistance, spawnDistance);
            Vector2 spawnPos = new Vector2(randX, randY);
            spawnPos += (Vector2)transform.position;

            GameObject enemy = Instantiate<GameObject>(enemyPrefab, spawnPos, Quaternion.identity);
            NetworkServer.Spawn(enemy);

            yield return new WaitForSeconds(spawnFrequencyInSecs);
        }
    }
}
