using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public class RoomFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator{
    [SerializeField]
    private int minRoomWidth= 4 , minRoomHeight = 4;
    [SerializeField]
    private int dungeonWidth =20, dungeonHeight = 20;
    [SerializeField] [Range(0,10)]
    private int offset = 1;
    [SerializeField]
    private bool randomWalkRooms = false;


    protected override void RunProceduralGeneration() {
        CreateRooms();
    }

    private void CreateRooms() {
        var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition, new Vector3Int(dungeonWidth, dungeonHeight, 0)), minRoomWidth, minRoomHeight);
        
        HashSet<Vector2Int> floor = new HashSet <Vector2Int>();

        if (randomWalkRooms) {
            
            floor = CreateRoomsRandomly(roomsList);
        }
        else {
            
            floor = CreateSimpleRooms(roomsList);
        }

        List<Vector2Int> roomCenters = new List<Vector2Int>();
        foreach (var room in roomsList) {
            roomCenters.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
            
        }
        HashSet<Vector2Int> corridors = ConnectRooms(roomCenters);
        floor.UnionWith(corridors);
        
        tilemapVisualizer.PaintFloorTiles(floor);
        WallGenerator.CreateWalls(floor,tilemapVisualizer);
    }

    private HashSet<Vector2Int> CreateRoomsRandomly(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        for (int i = 0; i < roomsList.Count; i++)
        {
            var roomBounds = roomsList[i];
            var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));
            var roomFloor = RunRandomWalk(randomWalkParameters, roomCenter);
            foreach (var position in roomFloor)
            {
                if(position.x >= (roomBounds.xMin + offset) && position.x <= (roomBounds.xMax - offset) && position.y >= (roomBounds.yMin - offset) && position.y <= (roomBounds.yMax - offset))
                {
                    floor.Add(position);
                }
            }
        }
        return floor;
    }

    private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> roomCenters) {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        var currentRoomsCenter = roomCenters[UnityEngine.Random.Range(0,roomCenters.Count)];
        roomCenters.Remove(currentRoomsCenter);

        while (roomCenters.Count > 0) {
            Vector2Int closest = FindClosestPointTo(currentRoomsCenter, roomCenters);
            roomCenters.Remove(closest);
            HashSet<Vector2Int> newCorridors = CreateCorridor(currentRoomsCenter, closest);
            currentRoomsCenter = closest;
            corridors.UnionWith(newCorridors);
        }
        return corridors;
    }

    private HashSet<Vector2Int> CreateCorridor(Vector2Int currentRoomsCenter, Vector2Int destination) {
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var position = currentRoomsCenter;
        corridor.Add(position);
        while (position.y != destination.y) {
            if (destination.y > position.y) {
                position += Vector2Int.up;
            }
            else if (destination.y < position.y) {
                position += Vector2Int.down;
            }
            corridor.Add(position);
        }
        while (position.x != destination.x) {
            if (destination.x > position.x) {
                position += Vector2Int.right;
            }
            else if (destination.x < position.x) {
                position += Vector2Int.left;
            }
            corridor.Add(position);
        }
        return corridor;
    }

    private Vector2Int FindClosestPointTo(Vector2Int currentRoomsCenter, List<Vector2Int> roomCenters) {
       Vector2Int closest = Vector2Int.zero;
       float distance = float.MaxValue;
       foreach (var position in roomCenters) {
           float currentDistance = Vector2.Distance(position, currentRoomsCenter);
           if (currentDistance < distance) {
               distance = currentDistance;
               closest = position;
               
           }
       }
       return closest;
    }

    private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomsList) {
      HashSet<Vector2Int> floor =new HashSet<Vector2Int>();
      foreach (var room in roomsList) {
          for (int col = offset; col < room.size.x - offset ; col++) {
              for (int row = offset; row < room.size.y- offset; row++) {
                  Vector2Int position = (Vector2Int)room.min + new Vector2Int(col,row);
                  floor.Add(position);
              } 
          }
      }
      return floor;
    }
}
