using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class MapTileExtensions
{
    public static string AsString(this GameMap.MapTiles[,] tiles)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Grid " + tiles.GetLength(0) + "x" + tiles.GetLength(1) + "\r\n");
        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                sb.Append("" + (int)tiles[x, y]);
            }
            sb.Append("\r\n");
        }
        return sb.ToString();
    }

    public static GameMap.MapTiles[,] CopyMap(this GameMap.MapTiles[,] tiles)
    {
        GameMap.MapTiles[,] toReturn = new GameMap.MapTiles[tiles.GetLength(0), tiles.GetLength(1)];
        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                toReturn[x, y] = tiles[x, y];
            }
        }

        return toReturn;
    }
}
