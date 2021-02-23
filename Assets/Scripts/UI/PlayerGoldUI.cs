using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGoldUI : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    TextMeshProUGUI textBox;

    [SerializeField]
    ItemDataSO goldItem;

    private void Start()
    {
        UpdateGold();
    }

    public void UpdateGold()
    {
        textBox.text = "Gold: " + player.Data.CurrentInventory.GetNumItems(goldItem);
    }
}
