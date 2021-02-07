using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/Item Data")]
public class ItemDataSO : ScriptableObject
{
    [Tooltip("Name of the item")]
    [SerializeField]
    string itemName;

    /// <summary>
    /// Name of the item
    /// </summary>
    /// <value></value>
    public string ItemName { get { return itemName; } }

    [Tooltip("True if player can only carry one of this item")]
    [SerializeField]
    bool canPlayerOnlyHaveOne;

    /// <summary>
    /// True if player can only carry one of this item
    /// </summary>
    /// <value></value>
    public bool CanPlayerOnlyHaveOne { get { return canPlayerOnlyHaveOne; } }
}
