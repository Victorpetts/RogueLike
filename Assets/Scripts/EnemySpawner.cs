using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    // private Vector2Int spawnPosition;
    // [SerializeField] private float minX, maxX, minY, maxY;

    public List<GameObject> enemyTypes = new List<GameObject>();
    public List<int> enemyProbabilities = new List<int>();
    
    // void Start() {
    //     SpawnEnemies();
    // }

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
                    // spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    Vector2 spawnPosition = floorPositions.ElementAt(Random.Range(0, 10));
                    // Vector2 test = spawnPosition;
                    Instantiate(enemyTypes[i], spawnPosition, Quaternion.identity);
                }
            }
            enemyCount ++;
        }
    }
}