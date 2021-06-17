using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/Inventory Data")]
public class InventorySO : ScriptableObject
{
    [Tooltip("Items currently in inventory")]
    [SerializeField]
    List<InventorySlot> currentInventory = new List<InventorySlot>();

    /// <summary>
    /// NOTE: This should only be used to read data, and not modify the collection
    /// </summary>
    /// <value></value>
    public List<InventorySlot> CurrentInventory { get { return currentInventory; } }

    [SerializeField]
    GameEvent onInventoryUpdated = null;

    public GameEvent OnInventoryUpdated { set { onInventoryUpdated = value; } }

    private void OnEnable()
    {
        Consolidate();
        CallUpdateEvent();
    }

    void CallUpdateEvent()
    {
        if (onInventoryUpdated != null)
        {
            onInventoryUpdated.Invoke();
        }
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
                return slot.Count >= count;
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
                CallUpdateEvent();
                return;
            }
        }

        currentInventory.Add(new InventorySlot() { Item = newSlot.Item, Count = newSlot.Count });
        CallUpdateEvent();
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

        for (int i = currentInventory.Count - 1; i >= 0; i--)
        {
            if (currentInventory[i].Item == toRemove)
            {
                currentInventory.RemoveAt(i);
            }
        }
        CallUpdateEvent();
    }

    public void RemoveItem(InventorySlot slot)
    {
        if (currentInventory.Count == 0)
        {
            return;
        }
        for (int i = currentInventory.Count - 1; i >= 0; i--)
        {
            if (currentInventory[i].Item == slot.Item)
            {
                var invSlot = currentInventory[i];
                invSlot.Count = (uint)Mathf.Max(0, invSlot.Count - slot.Count);
                if (invSlot.Count == 0)
                {
                    currentInventory.RemoveAt(i);
                }
                else
                {
                    currentInventory[i] = invSlot;
                }
            }
        }
        CallUpdateEvent();
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
        toReturn.onInventoryUpdated = this.onInventoryUpdated;
        toReturn.currentInventory = new List<InventorySlot>();
        foreach (var slot in currentInventory)
        {
            toReturn.AddItem(slot);
        }

        return toReturn;
    }

    public void Copy(InventorySO other)
    {
        other.Consolidate();
        this.currentInventory.Clear();
        Consolidate();

        foreach (var slot in other.currentInventory)
        {
            AddItem(slot);
        }
        this.onInventoryUpdated = other.onInventoryUpdated;

    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("Inventory: ");
        for (int i = 0; i < currentInventory.Count; i++)
        {
            sb.Append("" + currentInventory[i].Count + " " + currentInventory[i].Item);
            if (i != currentInventory.Count - 1)
            {
                sb.Append(", ");
            }
        }

        return sb.ToString();
    }
}
