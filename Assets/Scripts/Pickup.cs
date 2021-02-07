using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    InventorySO rewards = null;

    [SerializeField]
    bool disablesOnPickup = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.Data.CurrentInventory.AddItems(rewards);
            if (disablesOnPickup)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
