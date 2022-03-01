using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public List<GameObject> enemyTypes = new List<GameObject>();
    public List<int> enemyProbabilities = new List<int>();

    public void SpawnEnemies(IEnumerable<Vector2Int> floorPositions) {
        var enemyCount = 0;
        var spawns = Random.Range(2, 5);
        while (enemyCount < spawns) {
            var randomEnemy = Random.Range(1, 101);
            int low;
            int high = 0;
            for (int i = 0; i < enemyTypes.Count; i++) {
                low = high;
                high += enemyProbabilities[i];
                if (randomEnemy >= low && randomEnemy < high) {
                    Vector2 spawnPosition = floorPositions.ElementAt(Random.Range(0, 8));
                    Instantiate(enemyTypes[i], spawnPosition, Quaternion.identity);
                }
            }
            enemyCount ++;
        }
    }
}