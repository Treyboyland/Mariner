using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnNoEnergy : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    PlayerMovement movement = null;

    [SerializeField]
    float secondsToWait = 0;

    bool waitingForDeath;

    // Update is called once per frame
    void Update()
    {
        if (player.CurrentEnergy <= 0 && player.CurrentHealth != 0 && !waitingForDeath)
        {
            waitingForDeath = true;
            StartCoroutine(WaitThenDie());
        }
        else if (waitingForDeath && player.CurrentEnergy > 0)
        {
            movement.CanMove = true;
            waitingForDeath = false;
            StopAllCoroutines();
        }
    }

    IEnumerator WaitThenDie()
    {
        movement.CanMove = false;
        yield return new WaitForSeconds(secondsToWait);
        player.InstaKill();
        waitingForDeath = false;
    }
}
