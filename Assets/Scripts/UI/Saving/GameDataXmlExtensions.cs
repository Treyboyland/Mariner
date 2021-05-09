using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System;

public static class GameDataXmlExtensions
{
    static string ToXmlString(this Color color)
    {
        return "" + color.r + "," + color.g + "," + color.b + "," + color.a;
    }

    static Color GetColorFromXmlString(string colorString)
    {
        var colorData = colorString.Split(',');
        Color toReturn = new Color();
        toReturn.r = float.Parse(colorData[0]);
        toReturn.g = float.Parse(colorData[1]);
        toReturn.b = float.Parse(colorData[2]);
        toReturn.a = float.Parse(colorData[3]);

        return toReturn;
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

    public static bool GetPlayerDataFromXml(XElement xmlData, out PlayerDataSO playerData, List<ItemDataSO> items)
    {
        try
        {
            playerData = ScriptableObject.CreateInstance<PlayerDataSO>();
            playerData.MaxHealth = int.Parse(xmlData.Attribute("MaxHealth").Value);
            playerData.MaxDepth = int.Parse(xmlData.Attribute("MaxDepth").Value);
            playerData.MaxEnergy = float.Parse(xmlData.Attribute("MaxEnergy").Value);
            playerData.SaveTime = new System.DateTime(long.Parse(xmlData.Attribute("SaveTime").Value));
            playerData.FrontColor = GetColorFromXmlString(xmlData.Attribute("FrontColor").Value);
            playerData.BackColor = GetColorFromXmlString(xmlData.Attribute("BackColor").Value);
            playerData.CreateNewInventory();

            foreach (var inventory in xmlData.Descendants("Inventory"))
            {
                var otherInventory = GetInventoryFromXml(inventory, items);
                playerData.CurrentInventory.AddItems(otherInventory);
            }

            return true;
        }
        catch (Exception e)
        {
            Debug.LogError("Error parsing XML:\r\n" + e);
            playerData = null;
            return false;
        }



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

    public static InventorySO GetInventoryFromXml(XElement inv, List<ItemDataSO> items)
    {
        //Debug.LogWarning("Inventory node:\r\n" + inv);
        InventorySO toReturn = ScriptableObject.CreateInstance<InventorySO>();
        foreach (var item in inv.Descendants("Item"))
        {
            //Debug.LogWarning("Item node: " + item);
            string name = item.Attribute("Name").Value;
            uint count = uint.Parse(item.Attribute("Count").Value);

            foreach (var dataItem in items)
            {
                if (dataItem.ItemName == name)
                {
                    //Debug.LogWarning("Adding " + count + " " + dataItem.ItemName);
                    toReturn.AddItem(new InventorySlot() { Item = dataItem, Count = count });
                }
            }
        }

        return toReturn;
    }
}
