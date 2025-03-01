using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapVisualizer tilemapVisualizer) {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionList);
        var cornerWallPositions = FindWallsInDirections(floorPositions,Direction2D.diagonalDirectionList);
        CreateBasicWall(tilemapVisualizer, basicWallPositions, floorPositions);
        CreateCornerWalls(tilemapVisualizer, cornerWallPositions, floorPositions);
    }

    private static void CreateCornerWalls(TileMapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> 
            floorPositions) {
        foreach (var position in cornerWallPositions) {
            string neighboursBinarytype = "";
            foreach (var direction in Direction2D.eightDirectionsList) {
                var neightbourPostion = position + direction;
                if (floorPositions.Contains(neightbourPostion)) {
                    neighboursBinarytype += "1";
                }
                else {
                    neighboursBinarytype += "0";
                }
            }
            tilemapVisualizer.PaintSingleCornerWall(position, neighboursBinarytype);
        }
    }

    private static void CreateBasicWall(TileMapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPositions, HashSet<Vector2Int> floorPositions) {
        foreach (var postition in basicWallPositions) {
            string neighboursBinaryType = "";
            foreach (var direction in Direction2D.cardinalDirectionList) {
                var neighbourPosition = postition + direction;
                if (floorPositions.Contains(neighbourPosition)) {
                    neighboursBinaryType += "1";
                    
                }
                else {
                    neighboursBinaryType += "0";
                }
            }
            tilemapVisualizer.PaintSingleBasicWall(postition,neighboursBinaryType);

        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections (HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList) {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions) {
            
            foreach (var direction in directionList) {
                
                var neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
                
            }
        }
        return wallPositions;
    }
}
