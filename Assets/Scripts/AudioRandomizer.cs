using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioRandomizer : MonoBehaviour
{
    public abstract void RandomizeSource(AudioSource source);
}


public static class RandomX
{
    public static float Range(Vector2 vector)
    {
        return UnityEngine.Random.Range(vector.x, vector.y);
    }
}