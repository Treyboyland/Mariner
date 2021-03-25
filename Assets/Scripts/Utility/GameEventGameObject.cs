using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Game Object Event", order = -1)]
public class GameEventGameObject : GameEvent
{
    public GameObject GameObject { get; set; }
}
