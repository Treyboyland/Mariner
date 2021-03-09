using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropTableSO : ScriptableObject
{
    public abstract Pickup GetPickupForLocation(int x, int y);
}
