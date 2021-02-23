using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    InventorySO rewards = null;

    [SerializeField]
    bool disablesOnPickup = true;

    [SerializeField]
    GameEvent pickupEvent = null;


    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.Data.CurrentInventory.AddItems(rewards);
            if (pickupEvent != null)
            {
                pickupEvent.Invoke();
            }
            if (disablesOnPickup)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
