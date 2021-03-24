using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWallDamageCheck : MonoBehaviour
{
    [SerializeField]
    GameEventVector2 onPlayerCollision = null;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            var body = other.gameObject.GetComponent<Rigidbody2D>();
            if (body != null)
            {
                onPlayerCollision.Vector = other.relativeVelocity;
                onPlayerCollision.Invoke();
            }
        }
    }
}
