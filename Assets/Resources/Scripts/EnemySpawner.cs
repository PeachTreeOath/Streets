using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

    public GameObject enemyPrefab;
    public int numberOfEnemies;

    public override void OnStartServer()
    {
        base.OnStartServer();

        for (int i = 0; i < numberOfEnemies; i++)
        {
            float randX = UnityEngine.Random.Range(-8f, 8f);
            float randY = UnityEngine.Random.Range(-8f, 8f);
            Vector2 spawnPos = new Vector2(randX, randY);

            GameObject enemy = Instantiate<GameObject>(enemyPrefab, spawnPos, Quaternion.identity);
            NetworkServer.Spawn(enemy);
        }
    }
  
}
