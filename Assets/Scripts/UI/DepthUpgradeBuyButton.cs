using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DepthUpgradeBuyButton : MonoBehaviour
{
    [SerializeField]
    Player player = null; 

    [SerializeField]
    UpgradeCostSO purchaseTable = null;

    [SerializeField]
    ItemDataSO depthUpgrade = null;

    [SerializeField]
    ItemDataSO gold = null;

    [SerializeField]
    Button button = null;

    [SerializeField]
    TextMeshProUGUI textBox;

    uint currentCost = 0;

    private void OnEnable()
    {
        UpdateUpgradeCost();
    }

    public void UpdateUpgradeCost()
    {
        currentCost = purchaseTable.GetCostForCount(player.Data.CurrentInventory.GetNumItems(depthUpgrade));
        bool ableToBuy = player.Data.CurrentInventory.HasItem(gold, currentCost);
        button.interactable = ableToBuy;
        UpdateText(ableToBuy);
    }

    public void BuyUpgrade()
    {
        player.Data.CurrentInventory.RemoveItem(new InventorySlot { Item = gold, Count = currentCost });
        player.Data.CurrentInventory.AddItem(new InventorySlot { Item = depthUpgrade, Count = 1 });
    }

    void UpdateText(bool ableToBuy)
    {
        textBox.text = "Buy " + depthUpgrade.ItemName + "\r\n" + (ableToBuy ? "" : "Need ")
            + currentCost + " " + gold.ItemName;
    }
}
