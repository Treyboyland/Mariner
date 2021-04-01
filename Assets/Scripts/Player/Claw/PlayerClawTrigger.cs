using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClawTrigger : MonoBehaviour
{
    [SerializeField]
    GameEventGameObject onTreasureCloseToClaw = null;

    [SerializeField]
    GameEventGameObject onTreasureLeftClaw = null;

    const string TREASURE_MASK_NAME = "Treasure";

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckForTreasureEntering(other);
    }

    void CheckForTreasureEntering(Collider2D other)
    {
        //Note: PEMDAS, then bitwise - if object is on treasure mask
        if (IsOnTreasureLayer(other))
        {
            Debug.LogWarning(gameObject.name + ": Found: " + other.gameObject.name);
            onTreasureCloseToClaw.GameObject = other.gameObject;
            onTreasureCloseToClaw.Invoke();
        }
    }

    void CheckForTreasureLeaving(Collider2D other)
    {
        //Note: PEMDAS, then bitwise - if object is on treasure mask
        if (IsOnTreasureLayer(other))
        {
            Debug.LogWarning(gameObject.name + ": Leaving: " + other.gameObject.name);
            onTreasureLeftClaw.GameObject = other.gameObject;
            onTreasureLeftClaw.Invoke();
        }
    }

    bool IsOnTreasureLayer(Collider2D other)
    {
        return LayerMask.LayerToName(other.gameObject.layer) == TREASURE_MASK_NAME;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckForTreasureEntering(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CheckForTreasureLeaving(other);
    }
}
