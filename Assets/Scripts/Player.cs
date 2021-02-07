using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO playerData = null;

    public PlayerDataSO Data
    {
        get
        {
            return playerData;
        }
    }
}
