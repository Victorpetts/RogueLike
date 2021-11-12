using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    private int enemyCount;
    private Vector2 spawnPosition;
    [SerializeField] private float minX, maxX, minY, maxY;

    public List<GameObject> enemyTypes = new List<GameObject>();
    
    void Start() {
        SpawnEnemies();
    }

    void SpawnEnemies() {
        var spawns = Random.Range(2, 6);
        var index = enemyTypes.Count;
        var randomEnemy = Random.Range(0, index);

        while (enemyCount < spawns) {
            spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(enemyTypes[randomEnemy], spawnPosition, Quaternion.identity);
            enemyCount ++;
            randomEnemy = Random.Range(0, index);
        }
    }
}