using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObjectPool wallPool = null;

    [SerializeField]
    GameMap gameMap = null;

    [SerializeField]
    float unitDisatance = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MakeMap()
    {
        wallPool.DisableAll();

        var map = gameMap.MapPoints;
        float farLeft = -map.GetLength(0) * unitDisatance / 2 + .5f;
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Vector3 pos = new Vector3(farLeft + unitDisatance * x, -y * unitDisatance);
                if (map[x, y] == GameMap.MapTiles.WALL)
                {
                    var wall = wallPool.GetObject();
                    wall.transform.SetParent(transform);
                    wall.transform.localPosition = pos;
                    wall.gameObject.SetActive(true);
                }
            }
        }
    }
}
