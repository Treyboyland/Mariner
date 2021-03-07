using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthHullDamage : MonoBehaviour
{
    [SerializeField]
    int damage = 0;

    [SerializeField]
    float secondsBeforeDamageStarts = 0;

    [SerializeField]
    float secondsBetweenDamage = 0;

    [SerializeField]
    Player player = null;

    bool routineStarted = false;

    public void StartDamaging()
    {
        if (!routineStarted)
        {
            StartCoroutine(DamageCoroutine());
        }
    }

    public void StopDamaging()
    {
        StopAllCoroutines();
        routineStarted = false;
    }


    IEnumerator DamageCoroutine()
    {
        routineStarted = true;
        yield return new WaitForSeconds(secondsBeforeDamageStarts);

        while (true)
        {
            player.TakeDamage(damage);
            yield return new WaitForSeconds(secondsBetweenDamage);
        }
    }
}
