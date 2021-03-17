using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorBuyButton : MonoBehaviour
{
    [SerializeField]
    InventorySlot goldCount = new InventorySlot();

    [SerializeField]
    Button button = null;

    [SerializeField]
    TextMeshProUGUI textBox = null;

    [SerializeField]
    Player player = null;

    [SerializeField]
    ColorSO textActiveColor = null;

    [SerializeField]
    ColorSO textNotActiveColor = null;

    private void OnEnable()
    {
        bool hasItem = player.Data.CurrentInventory.HasItem(goldCount.Item, goldCount.Count);
        button.interactable = hasItem;
        textBox.text = hasItem ? "Buy\r\n" + goldCount : "Cannot Buy\r\nNeed " + goldCount;
        textBox.faceColor = hasItem ? textActiveColor.Color : textNotActiveColor.Color;
    }

    public void DeductMoney()
    {
        player.Data.CurrentInventory.RemoveItem(goldCount);
    }
}
