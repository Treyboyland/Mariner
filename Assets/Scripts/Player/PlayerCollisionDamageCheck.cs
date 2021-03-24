using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamageCheck : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D playerRidgidbody = null;

    [SerializeField]
    Player player = null;

    [SerializeField]
    PlayerCollisionThresholdDataSO collisionThresholdDataSO = null;

    [SerializeField]
    GameEventVector2 eventVector2 = null;

    public void CheckForDamage()
    {
        //TOOD: Need relative velocity of collision...
        float magnitude = eventVector2.Vector.sqrMagnitude;
        Debug.LogWarning("Magnitude: " + magnitude);
        

        if (magnitude > collisionThresholdDataSO.MagnitudeThreshold)
        {
            player.TakeDamage(collisionThresholdDataSO.Damage);
        }
    }
}
