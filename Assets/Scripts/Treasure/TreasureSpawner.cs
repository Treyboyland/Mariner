using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    [SerializeField]
    Vector4 spawnRanges = new Vector4();

    [SerializeField]
    float spaceBetweenCalculations = 0;

    [SerializeField]
    int raycastsPerFrame = 0;

    [SerializeField]
    GameEvent spawnCheckComplete = null;

    List<Vector3> validSpawnLocations = new List<Vector3>();

    public List<Vector3> ValidSpawnLocations { get { return validSpawnLocations; } }

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CalculateValidSpawns());
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
    }


    IEnumerator CalculateValidSpawns()
    {
        int count = 0;
        for (float x = spawnRanges.x; x < spawnRanges.y; x += spaceBetweenCalculations)
        {
            for (float y = spawnRanges.z; y > spawnRanges.w; y -= spaceBetweenCalculations)
            {
                count++;
                var location = new Vector2(x, y);
                var hit = Physics2D.Raycast(location, Vector2.up, Mathf.Epsilon, LayerMask.GetMask("Ground"));
                if (hit.collider == null)
                {
                    validSpawnLocations.Add(location);
                }
                if (count >= raycastsPerFrame)
                {
                    count = 0;
                    yield return null;
                }
                // if (validSpawnLocations.Count % 1000 == 0)
                // {
                //     Debug.LogWarning("Current Location: " + location);
                // }
            }
        }

        Debug.LogWarning("Time to calculate: " + elapsed + " Valid positions: " + validSpawnLocations.Count);
        spawnCheckComplete.Invoke();
    }
}
