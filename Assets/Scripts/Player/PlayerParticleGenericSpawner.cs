using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleGenericSpawner : MonoBehaviour
{
    [SerializeField]
    ParticlePool pool = null;


    [SerializeField]
    Player player = null;

    [SerializeField]
    Transform waterTransform;

    public void SpawnParticle()
    {
        var particle = pool.GetObject().GetComponent<ParticleSystem>();
        particle.transform.position = player.transform.position;
        var main = particle.trigger;
        main.SetCollider(0, waterTransform);
        particle.gameObject.SetActive(true);
    }
}
