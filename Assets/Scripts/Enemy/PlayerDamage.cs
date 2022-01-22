using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    int damage = 0;

    [SerializeField]
    bool hitsOnce = false;

    bool isHit = false;

    public UnityEvent OnPlayerDamaged;

    private void OnDisable()
    {
        isHit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null && (!hitsOnce || hitsOnce && !isHit))
        {
            isHit = true;
            player.TakeDamage(damage);
            OnPlayerDamaged.Invoke();
        }
    }

    public void SetTransForm(GameEventVector2 gameEvent)
    {
        gameEvent.Vector = transform.position;
    }
}
