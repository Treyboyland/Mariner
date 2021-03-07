using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientBubbles : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles = null;

    public void SetDeathCollider(Component collider)
    {
        var main = particles.trigger;
        main.SetCollider(0, collider);
    }
}
