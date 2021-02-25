using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [Tooltip("Current items the player has")]
    [SerializeField]
    InventorySO currentInventory = null;

    /// <summary>
    /// Current items the player has
    /// </summary>
    /// <value></value>
    public InventorySO CurrentInventory { get { return currentInventory; } }
}
