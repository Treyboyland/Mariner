using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapGenerator : MonoBehaviour
{
    [SerializeField]
    GameWallPool wallPool = null;

    [SerializeField]
    GameMap gameMap = null;

    [SerializeField]
    float unitDistance = 1;

    [SerializeField]
    bool singleBlocks = false;

    [SerializeField]
    MapTreasureSpawner treasureSpawner = null;

    [SerializeField]
    Transform wallTransform = null;

    [SerializeField]
    Transform treasureTransform = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector2 OptimizeWalls(GameMap.MapTiles[,] map, int x, int y)
    {
        if (map[x, y] != GameMap.MapTiles.WALL)
        {
            return new Vector2Int();
        }
        if (singleBlocks)
        {
            map[x, y] = GameMap.MapTiles.WALL_COMPLETE;
            return new Vector2(unitDistance, unitDistance);
        }
        /// <summary>
        /// So, what this hopefully does is iterate the furthest to the right,
        /// and then downwards for each column, and then finds the greatest area
        /// between them
        /// </summary>

        int countY = 0;
        int countX = 0;
        List<Vector2> potentialBoxes = new List<Vector2>();
        while (x + countX < map.GetLength(0))
        {
            if (map[x + countX, y] != GameMap.MapTiles.WALL)
            {
                break;
            }
            countX++;
        }

        int maxY = int.MaxValue;

        for (int i = 0; i < countX; i++)
        {
            countY = 0;
            while (y + countY < map.GetLength(1))
            {
                if (map[x + i, y + countY] != GameMap.MapTiles.WALL || countY > maxY)
                {
                    break;
                }
                countY++;
            }
            if (countY < maxY)
            {
                maxY = countY;
            }
            potentialBoxes.Add(new Vector2Int(i + 1, maxY));
        }

        int chosenIndex = 0;
        int maxArea = int.MinValue;

        for (int i = 0; i < potentialBoxes.Count; i++)
        {
            var dimensions = potentialBoxes[i];
            int area = (int)dimensions.x * (int)dimensions.y;
            if (area > maxArea)
            {
                maxArea = area;
                chosenIndex = i;
            }
        }

        var selectedDimesnions = potentialBoxes[chosenIndex];
        for (int xVal = x; xVal < x + selectedDimesnions.x; xVal++)
        {
            for (int yVal = y; yVal < y + selectedDimesnions.y; yVal++)
            {
                if (map[xVal, yVal] != GameMap.MapTiles.WALL)
                {
                    throw new System.Exception("Algorithm is wrong (" + xVal + ", " + yVal + ")");
                }
                map[xVal, yVal] = GameMap.MapTiles.WALL_COMPLETE;
            }
        }
        selectedDimesnions.x *= unitDistance;
        selectedDimesnions.y *= unitDistance;
        return selectedDimesnions;
    }

    public void MakeMap()
    {
        wallPool.DisableAll();
        treasureSpawner.DisableAll();

        var map = gameMap.MapPoints.CopyMap();
        //Debug.LogWarning(map.AsString());
        float farLeft = -map.GetLength(0) * unitDistance / 2 + .5f;
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Vector3 pos = new Vector3(farLeft + unitDistance * x, -y * unitDistance);
                if (map[x, y] == GameMap.MapTiles.WALL)
                {
                    var wall = wallPool.GetObject();
                    wall.transform.SetParent(wallTransform);
                    wall.transform.localPosition = pos;
                    wall.SetScale(OptimizeWalls(map, x, y));
                    wall.gameObject.SetActive(true);
                }
                else if (map[x, y] == GameMap.MapTiles.BLANK && gameMap.ShouldSpawnTreasure)
                {
                    treasureSpawner.SpawnTreasure(treasureTransform, x, y, pos);
                }
            }
        }
        //Debug.LogWarning(map.AsString());
    }
}
