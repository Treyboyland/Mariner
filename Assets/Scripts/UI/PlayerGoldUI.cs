using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGoldUI : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    TextMeshProUGUI textBox = null;

    [SerializeField]
    ItemDataSO goldItem = null;

    private void OnEnable()
    {
        UpdateGold();
    }

    public void UpdateGold()
    {
        textBox.text = "Gold: " + player.Data.CurrentInventory.GetNumItems(goldItem);
    }
}
