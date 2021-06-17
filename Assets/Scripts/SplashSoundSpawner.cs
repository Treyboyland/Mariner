using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSoundSpawner : MonoBehaviour
{
    [SerializeField]
    GameObjectPool pool;

    [SerializeField]
    AudioRandomizer randomizer;

    [SerializeField]
    GameEvent exitedWaterInitial;

    bool inWater = true;

    public bool InWater
    {
        set
        {
            if (value == false && inWater != value)
            {
                exitedWaterInitial.Invoke();
                SpawnSound();
            }
            inWater = value;
        }
    }

    public void SpawnSound()
    {
        var obj = pool.GetObject().GetComponent<AudioSource>();
        obj.gameObject.SetActive(true);
        randomizer.RandomizeSource(obj);
    }
}
