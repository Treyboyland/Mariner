using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightChanger : MonoBehaviour
{
    [SerializeField]
    Transform lightTransform;

    [SerializeField]
    Player player;

    [SerializeField]
    ItemDataSO lightUpgrade;

    [SerializeField]
    CountTableSO lightTransformScaleTable;

    // Start is called before the first frame update
    void Start()
    {
        UpdateX();
    }

    void SetX(float newX)
    {
        var scale = lightTransform.localScale;
        scale.x = newX;
        lightTransform.localScale = scale;
    }

    public void UpdateX()
    {
        SetX(lightTransformScaleTable.GetCostForCount(player.Data.CurrentInventory.GetNumItems(lightUpgrade)));
    }
}
