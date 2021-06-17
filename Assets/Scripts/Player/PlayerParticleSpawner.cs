using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleSpawner : MonoBehaviour
{
    [SerializeField]
    ParticlePool pool = null;


    [SerializeField]
    Player player = null;

    public void SpawnParticle()
    {
        var particle = pool.GetObject().GetComponent<PlayerParticleColorSetter>();
        particle.SetMainColor(player.Data.FrontColor, player.Data.BackColor);
        particle.transform.position = player.transform.position;
        particle.gameObject.SetActive(true);
    }
}
