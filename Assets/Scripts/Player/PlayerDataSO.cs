using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [Tooltip("The player's maximum health points")]
    [SerializeField]
    int maxHealth = 0;

    /// <summary>
    /// The player's maximum health points
    /// </summary>
    public int MaxHealth { get { return maxHealth; } }

    [Tooltip("Current items the player has")]
    [SerializeField]
    InventorySO currentInventory = null;

    /// <summary>
    /// Current items the player has
    /// </summary>
    /// <value></value>
    public InventorySO CurrentInventory { get { return currentInventory; } }

    [Tooltip("The depth at which the player will start taking damage")]
    [SerializeField]
    float maxDepth = 0;

    /// <summary>
    /// The depth at which the player will start taking damage
    /// </summary>
    /// <value></value>
    public float MaxDepth { get { return maxDepth; } }
}
