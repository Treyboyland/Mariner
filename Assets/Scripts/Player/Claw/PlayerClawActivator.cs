using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClawActivator : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    GameObject claw = null;

    [SerializeField]
    ItemDataSO clawUpgrade = null;

    // Start is called before the first frame update
    void Start()
    {
        RunCheck();
    }


    public void RunCheck()
    {
        bool hasItem = player.Data.CurrentInventory.HasItem(clawUpgrade);
        if (claw.activeInHierarchy && !hasItem)
        {
            claw.SetActive(false);
        }
        else if (!claw.activeInHierarchy && hasItem)
        {
            claw.SetActive(true);
        }
    }
}
