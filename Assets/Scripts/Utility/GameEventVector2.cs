using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventVector", menuName = "Events/Game Event Vector", order = 2)]
public class GameEventVector2 : GameEvent
{
    /// <summary>
    /// Vector attached to this event
    /// </summary>
    /// <value></value>
    public Vector2 Vector { get; set; }
}
