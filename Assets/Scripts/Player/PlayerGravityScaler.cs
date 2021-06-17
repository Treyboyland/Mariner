using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityScaler : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    Rigidbody2D playerBody = null;

    [SerializeField]
    float outOfWaterScale = 0;

    [SerializeField]
    float normalScale = 0;

    [SerializeField]
    ItemDataSO mysteriousItem = null;

    public void SetInWaterScale()
    {
        playerBody.gravityScale = normalScale;
    }

    public void SetOutOfWaterScale()
    {
        playerBody.gravityScale = player.Data.CurrentInventory.HasItem(mysteriousItem) ? normalScale : outOfWaterScale;
    }
}
