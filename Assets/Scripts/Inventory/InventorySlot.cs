using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct InventorySlot
{
    public ItemDataSO Item;

    public uint Count;

    public override string ToString()
    {
        return Count + " " + Item.ItemName;
    }
}
