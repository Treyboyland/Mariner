using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCreator : MonoBehaviour
{
    [SerializeField]
    Vector2Int spikeRange;

    [SerializeField]
    GameObject spikePrefab;

    List<GameObject> allSpikes = new List<GameObject>();

    int numSpikes;

    // Start is called before the first frame update
    void Start()
    {
        numSpikes = Random.Range(spikeRange.x, spikeRange.y + 1);
        CreateSpikes();
    }

    GameObject AddSpike()
    {
        var spike = Instantiate(spikePrefab, new Vector3(), Quaternion.identity, transform);
        spike.SetActive(false);

        allSpikes.Add(spike);

        return spike;
    }

    GameObject GetSpike()
    {
        foreach (var spike in allSpikes)
        {
            if (!spike.activeInHierarchy)
            {
                return spike;
            }
        }

        return AddSpike();
    }

    void CreateSpikes()
    {
        float rotationPerSpike = 360.0f / numSpikes;
        for (int i = 0; i < numSpikes; i++)
        {
            Vector3 rotation = new Vector3(0, 0, rotationPerSpike * i);
            var spike = GetSpike();
            spike.transform.rotation = Quaternion.Euler(rotation);
            spike.transform.SetParent(transform);
            spike.transform.localPosition = new Vector3();
            spike.SetActive(true);
        }
    }
}
