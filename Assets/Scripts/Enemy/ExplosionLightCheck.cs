using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLightCheck : MonoBehaviour
{
    [SerializeField]
    ExplosionEnemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var light = other.GetComponent<PlayerLight>();
        if (light != null)
        {
            enemy.FizzleOut = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var light = other.GetComponent<PlayerLight>();
        if (light != null)
        {
            enemy.FizzleOut = false;
        }
    }
}
