using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour {
    [SerializeField] private Tilemap floorTilemap;
    [SerializeField] private Tilemap exitTilemap;
    [SerializeField] private TileBase floorTile;
    [SerializeField] private TileBase exitTile;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions) {
        PaintTiles(floorPositions, floorTilemap, floorTile);
        PaintExit(floorPositions, exitTilemap, exitTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile) {
        foreach (var position in positions) {
            PaintSingleTile(tilemap, tile, position);
        }
    }
    private void PaintExit(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile) {
        var exitPos = positions.ElementAt(Random.Range(0, positions.Count()));
        PaintSingleTile(tilemap, tile, exitPos);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position) {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear() {
        floorTilemap.ClearAllTiles();
        exitTilemap.ClearAllTiles();
    }
}
