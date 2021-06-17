using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupParticleSpawner : MonoBehaviour
{
    [SerializeField]
    ParticlePool pool = null;

    [SerializeField]
    GameEventVector2 pickupEvent;

    public void SpawnParticle()
    {
        var particle = pool.GetObject().GetComponent<PlayerParticleColorSetter>();

        particle.transform.position = pickupEvent.Vector;
        particle.gameObject.SetActive(true);
    }
}
