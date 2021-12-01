using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator {
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer) {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionList);
        
        foreach (var position in (IEnumerable<Vector2Int>)basicWallPositions) {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }

    private static object FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList) {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        
        foreach (var position in floorPositions) {
            foreach (var direction in directionList) {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
            }
        }
        
        return wallPositions;
    }
}
