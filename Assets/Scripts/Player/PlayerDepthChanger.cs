using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepthChanger : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    ItemDataSO depthUpgrade = null;

    [SerializeField]
    CountTableSO depthPerItem = null;


    public void UpdateMaxDepth()
    {
        player.Data.MaxDepth = depthPerItem.GetCostForCount(player.Data.CurrentInventory.GetNumItems(depthUpgrade));
    }
}
