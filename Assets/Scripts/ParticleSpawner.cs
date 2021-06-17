using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    ParticlePool pool = null;

    [SerializeField]
    GameEventVector2 pickupEvent;

    public void SpawnParticle()
    {
        var particle = pool.GetObject();

        particle.transform.position = pickupEvent.Vector;
        particle.gameObject.SetActive(true);
    }
}
