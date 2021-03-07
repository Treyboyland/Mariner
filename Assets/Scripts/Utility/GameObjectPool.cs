using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab = null;

    [SerializeField]
    int initialSize = 1;

    List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }


    void Initialize()
    {
        for (int i = 0; i < initialSize; i++)
        {
            CreateObject();
        }
    }

    GameObject CreateObject()
    {
        var newObject = Instantiate(objectPrefab, transform);
        newObject.SetActive(false);
        objects.Add(newObject);

        return newObject;
    }

    /// <summary>
    /// NOTE: Callers should make sure to set retrieved object active before calling for another one
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject()
    {
        foreach (var obj in objects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public void DisableAll()
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
