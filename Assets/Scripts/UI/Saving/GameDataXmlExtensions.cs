using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public static class GameDataXmlExtensions
{
    static string ToXmlString(this Color color)
    {
        return "" + color.r + "," + color.g + "," + color.b + "," + color.a;
    }



    public static XElement ToXml(this PlayerDataSO data)
    {
        XElement player = new XElement("Player",
            new XAttribute("MaxHealth", data.MaxHealth),
            new XAttribute("MaxDepth", data.MaxDepth),
            new XAttribute("MaxEnergy", data.MaxEnergy),
            new XAttribute("SaveTime", data.SaveTime.Ticks),
            new XAttribute("FrontColor", data.FrontColor.ToXmlString()),
            new XAttribute("BackColor", data.BackColor.ToXmlString()),
            data.CurrentInventory.ToXml()
        );

        return player;
    }

    public static XElement ToXml(this InventorySO data)
    {
        XElement inventory = new XElement("Inventory");
        foreach (var slot in data.CurrentInventory)
        {
            inventory.Add(slot.ToXml());
        }

        return inventory;
    }

    public static XElement ToXml(this InventorySlot data)
    {
        XElement slot = new XElement("Item",
        new XAttribute("Name", data.Item.ItemName),
        new XAttribute("Count", data.Count)
        );

        return slot;
    }
}
