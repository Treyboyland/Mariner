using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<EnemyPoolMap> pools = null;

    [SerializeField]
    DropTableEnemyCurveSO dropTable = null;

    [SerializeField]
    EnemyPool defaultPool = null;

    Dictionary<Enemy, EnemyPool> poolMap = new Dictionary<Enemy, EnemyPool>();

    private void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        foreach (var p in pools)
        {
            poolMap.Add(p.Enemy, p.Pool);
        }
    }

    public void DisableAll()
    {
        foreach (var p in poolMap.Values)
        {
            p.DisableAll();
        }
    }

    void SpawnEnemyPrefab(Transform parent, EnemyPool pool, Vector3 position)
    {
        Enemy temp = pool.GetObject();
        temp.transform.SetParent(parent);
        temp.transform.localPosition = position;
        temp.gameObject.SetActive(true);
    }

    public void SpawnEnemy(Transform parent, int x, int y, Vector3 position)
    {
        var pickup = dropTable.GetDropForLocation(x, y);
        if (!poolMap.ContainsKey(pickup))
        {
            Debug.LogWarning(gameObject.name + ": Pool Map Does not contain " + pickup.gameObject.name);
            SpawnEnemyPrefab(parent, defaultPool, position);
            return;
        }

        SpawnEnemyPrefab(parent, poolMap[pickup], position);
    }
}
