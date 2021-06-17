using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerDirection", menuName = "Player/Direction")]
public class PlayerDirection : GameEvent
{
    [SerializeField]
    string directionName = null;

    public string DirectionName { get { return directionName; } }
}
