using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Int Event", order = -1)]
public class GameEventInt : GameEvent
{
    [Tooltip("Value to be passed around")]
    [SerializeField]
    int intValue;

    /// <summary>
    /// Value to be passed around
    /// </summary>
    /// <value></value>
    public int IntValue
    {
        get
        {
            return intValue;
        }
        set
        {
            intValue = value;
        }
    }
}
