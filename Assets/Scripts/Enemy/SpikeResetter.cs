using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeResetter : MonoBehaviour
{
    [SerializeField]
    Animator enemy = null;

    public void ResetAttack()
    {
        enemy.ResetTrigger("Attack");
    }
}
