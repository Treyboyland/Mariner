using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    [SerializeField]
    Vector2Int dimensions;

    [Range(0, 100)]
    [SerializeField]
    int wallProbability = 50;

    [SerializeField]
    int numSmoothingOperations = 0;

    [SerializeField]
    GameEvent onMapGenerated = null;

    public enum MapTiles
    {
        INVALID = -1,
        BLANK,
        WALL,
    }

    MapTiles[,] mapPoints;

    public MapTiles[,] MapPoints { get { return mapPoints; } }

    // Start is called before the first frame update
    void Start()
    {
        InitializeMap();
        GenerateMap();
    }

    void InitializeMap()
    {
        mapPoints = new MapTiles[dimensions.x, dimensions.y];
        for (int x = 0; x < mapPoints.GetLength(0); x++)
        {
            for (int y = 0; y < mapPoints.GetLength(1); y++)
            {
                mapPoints[x, y] = MapTiles.BLANK;
            }
        }
    }

    bool IsWithinBounds(int x, int dx, int y, int dy)
    {
        var sumX = x + dx;
        var sumY = y + dy;
        return sumX >= 0 && sumX < mapPoints.GetLength(0) &&
            sumY >= 0 && sumY < mapPoints.GetLength(1);
    }

    int GetNumNeighbors(int x, int y, MapTiles toCheck)
    {
        int neighbors = 0;
        //Get 8 surrounding tiles
        for (int dx = -1; dx < 2; dx++)
        {
            for (int dy = -1; dy < 2; dy++)
            {
                var newX = x + dx;
                var newY = y + dy;

                if (!IsWithinBounds(x, dx, y, dy) || (newX == x && newY == y))
                {
                    continue;
                }
                if (mapPoints[newX, newY] == toCheck)
                {
                    neighbors++;
                }
            }
        }

        return neighbors;
    }

    MapTiles GetRandomizedTile()
    {
        int roll = Random.Range(0, 100);
        return roll < wallProbability ? MapTiles.WALL : MapTiles.BLANK;
    }

    void Smooth()
    {
        for (int x = 0; x < mapPoints.GetLength(0); x++)
        {
            for (int y = 0; y < mapPoints.GetLength(1); y++)
            {
                var blankNeighbors = GetNumNeighbors(x, y, MapTiles.BLANK);
                if (blankNeighbors < 4)
                {
                    mapPoints[x, y] = MapTiles.WALL;
                }
                if (blankNeighbors > 6)
                {
                    mapPoints[x, y] = MapTiles.BLANK;
                }
            }
        }

    }

    public void RegenerateMap()
    {
        InitializeMap();
        GenerateMap();
    }


    void GenerateMap()
    {
        for (int x = 0; x < mapPoints.GetLength(0); x++)
        {
            for (int y = 0; y < mapPoints.GetLength(1); y++)
            {
                mapPoints[x, y] = GetRandomizedTile();
            }
        }
        //Debug.LogWarning(mapPoints.AsString());

        for (int i = 0; i < numSmoothingOperations; i++)
        {
            Smooth();
        }

        //Debug.LogWarning(mapPoints.AsString());
        onMapGenerated.Invoke();
    }
}
