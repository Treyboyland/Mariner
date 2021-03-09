using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropTableSingle", menuName = "Pickup/Drop Table/Single", order = 1)]
public class DropTableSingleSO : DropTableSO
{
    [Tooltip("The single pickup that will spawn")]
    [SerializeField]
    Pickup pickupToSpwan = null;

    public override Pickup GetPickupForLocation(int x, int y)
    {
        return pickupToSpwan;
    }
}
