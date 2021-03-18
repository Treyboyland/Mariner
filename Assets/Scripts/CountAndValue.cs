using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct CountAndValue
{
    /// <summary>
    /// Number of an item that the player currently has in their inventory
    /// </summary>
    public uint Count;
    /// <summary>
    /// Value associated with this count
    /// </summary>
    public float Value;

}
