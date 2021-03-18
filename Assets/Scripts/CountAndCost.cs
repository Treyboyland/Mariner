using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct CountAndCost 
{
    /// <summary>
    /// Number of an item that the player currently has in their inventory
    /// </summary>
    public uint Count;
    /// <summary>
    /// Cost of the next upgrade
    /// </summary>
    public uint Cost;
}
