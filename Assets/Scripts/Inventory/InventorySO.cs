using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/Inventory Data")]
public class InventorySO : ScriptableObject
{
    [Tooltip("Items currently in inventory")]
    [SerializeField]
    List<InventorySlot> currentInventory = new List<InventorySlot>();


    private void OnEnable()
    {
        Consolidate();
    }

    public bool HasItem(ItemDataSO toCheck)
    {
        foreach (var slot in currentInventory)
        {
            if (slot.Item == toCheck)
            {
                return slot.Count > 0;
            }
        }

        return false;
    }

    public bool HasItem(ItemDataSO toCheck, uint count)
    {
        foreach (var slot in currentInventory)
        {
            if (slot.Item == toCheck)
            {
                return slot.Count > count;
            }
        }

        return false;

    }

    public void AddItem(InventorySlot newSlot)
    {
        for (int i = 0; i < currentInventory.Count; i++)
        {
            var slot = currentInventory[i];
            if (slot.Item == newSlot.Item)
            {
                slot.Count += newSlot.Count;
                currentInventory[i] = slot;
                return;
            }
        }

        currentInventory.Add(newSlot);
    }

    public void AddItems(InventorySO newItems)
    {
        foreach (var slot in newItems.currentInventory)
        {
            AddItem(slot);
        }
    }

    public void RemoveItem(ItemDataSO toRemove)
    {
        if (currentInventory.Count == 0)
        {
            return;
        }

        for (int i = currentInventory.Count; i >= 0; i--)
        {
            if (currentInventory[i].Item == toRemove)
            {
                currentInventory.RemoveAt(i);
            }
        }
    }

    public void Consolidate()
    {
        //A dictionary would be a better type for inventory, but they are not currently able to be used in editor...
        Dictionary<ItemDataSO, uint> counts = new Dictionary<ItemDataSO, uint>();

        foreach (var slot in currentInventory)
        {
            if (slot.Item == null)
            {
                continue;
            }
            if (!counts.ContainsKey(slot.Item))
            {
                counts.Add(slot.Item, 0);
            }
            counts[slot.Item] += slot.Count;
        }

        currentInventory.Clear();

        foreach (var data in counts)
        {
            currentInventory.Add(new InventorySlot() { Item = data.Key, Count = data.Value });
        }
    }

    public uint GetNumItems(ItemDataSO toCheck)
    {
        foreach (var slot in currentInventory)
        {
            if (slot.Item == toCheck)
            {
                return slot.Count;
            }
        }

        return 0;
    }

    public InventorySO Copy()
    {
        Consolidate();
        InventorySO toReturn = ScriptableObject.CreateInstance<InventorySO>();
        toReturn.currentInventory = new List<InventorySlot>();
        foreach (var slot in currentInventory)
        {
            toReturn.AddItem(slot);
        }

        return toReturn;
    }
}
