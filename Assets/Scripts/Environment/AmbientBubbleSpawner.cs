using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientBubbleSpawner : MonoBehaviour
{
    [SerializeField]
    Vector2 secondsBetweenBubbleSpawns = new Vector2();

    [SerializeField]
    Vector2Int numberOfBubblesToSpawn = new Vector2Int();

    [SerializeField]
    Transform center = null;

    [SerializeField]
    Vector4 offsets = new Vector4();


    [SerializeField]
    BubblePool bubblePool = null;

    [SerializeField]
    Transform waterCollider = null;

    float elapsed = 0;

    float secondsToWait = 0;

    // Start is called before the first frame update
    void Start()
    {
        RestartTime();
    }

    void RestartTime()
    {
        elapsed = 0;
        secondsToWait = Random.Range(secondsBetweenBubbleSpawns.x, secondsBetweenBubbleSpawns.y);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= secondsToWait)
        {
            RestartTime();
            SpawnBubbles();
        }
    }

    void SpawnBubbles()
    {
        int numToSpawn = Random.Range(numberOfBubblesToSpawn.x, numberOfBubblesToSpawn.y);

        for (int i = 0; i < numToSpawn; i++)
        {
            var bubble = bubblePool.GetObject();
            var x = Random.Range(offsets.x, offsets.y);
            var y = Random.Range(offsets.z, offsets.w);
            bubble.transform.position = center.position + new Vector3(x, y);
            bubble.SetDeathCollider(waterCollider);
            bubble.gameObject.SetActive(true);
        }
    }
}
