using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    private int enemyCount;
    private Vector2 spawnPosition;
    [SerializeField] private float minX, maxX, minY, maxY;

    public List<GameObject> enemyTypes = new List<GameObject>();
    public List<int> enemyProbabilities = new List<int>();
    
    void Start() {
        SpawnEnemies();
    }

    void SpawnEnemies() {
        var spawns = Random.Range(2, 6);
        while (enemyCount < spawns) {
            var randomEnemy = Random.Range(1, 101);
            int low;
            int high = 0;
            for (int i = 0; i < enemyTypes.Count; i++) {
                low = high;
                high += enemyProbabilities[i];
                if (randomEnemy >= low && randomEnemy < high) {
                    spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    Instantiate(enemyTypes[i], spawnPosition, Quaternion.identity);
                }
            }
            enemyCount ++;
        }
    }
}