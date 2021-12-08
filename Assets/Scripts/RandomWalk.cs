using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : AbstractDungeonGenerator {
    [SerializeField] private int iterations = 100;
    [SerializeField] private int walkLength = 20;

    protected override void RunProceduralGeneration() {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        enemySpawner.SpawnEnemies(floorPositions);
    }

    protected HashSet<Vector2Int> RunRandomWalk() {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        
        for (int i = 0; i < iterations; i++) {
            var path = GenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
        }
        
        return floorPositions;
    }
}
