using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubbles : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle = null;


    public void Play()
    {
        if (!particle.isPlaying)
        {
            particle.Play();
        }
    }

    public void Stop()
    {
        if (particle.isPlaying)
        {
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
