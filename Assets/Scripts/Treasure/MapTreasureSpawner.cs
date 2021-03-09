using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTreasureSpawner : MonoBehaviour
{
    [SerializeField]
    List<PickupPoolMap> pools = null;

    [SerializeField]
    DropTableSO dropTable = null;

    [SerializeField]
    PickupPool defaultPool = null;

    Dictionary<Pickup, PickupPool> poolMap = new Dictionary<Pickup, PickupPool>();

    private void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        foreach (var p in pools)
        {
            poolMap.Add(p.Pickup, p.Pool);
        }
    }

    public void DisableAll()
    {
        foreach (var p in poolMap.Values)
        {
            p.DisableAll();
        }
    }

    void SpawnTreasureItem(Transform parent, PickupPool pool, Vector3 position)
    {
        Pickup temp = pool.GetObject();
        temp.transform.SetParent(parent);
        temp.transform.localPosition = position;
        temp.gameObject.SetActive(true);
    }

    public void SpawnTreasure(Transform parent, int x, int y, Vector3 position)
    {
        var pickup = dropTable.GetPickupForLocation(x, y);
        if (!poolMap.ContainsKey(pickup))
        {
            Debug.LogWarning(gameObject.name + ": Pool Map Does not contain " + pickup.gameObject.name);
            SpawnTreasureItem(parent, defaultPool, position);
            return;
        }

        SpawnTreasureItem(parent, poolMap[pickup], position);
    }
}
