using System.Collections.Generic;
using UnityEngine;

public class SkyParticles : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles;

    public void StopParticlesClear()
    {
        Debug.Log(gameObject.name + ": Stopping particles");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void StopParticles()
    {
        Debug.Log(gameObject.name + ": Stopping particles");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void PlayParticles()
    {
        Debug.Log(gameObject.name + ": Playing particles");
        particles.Play(true);
    }
}
