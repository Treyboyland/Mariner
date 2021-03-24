using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollisionDamageData", menuName = "Player/Collision Data")]
public class PlayerCollisionThresholdDataSO : ScriptableObject
{
    [Tooltip("Value above which damage should be dealt to the player")]
    [SerializeField]
    float magnitudeThreshold = 0;

    /// <summary>
    /// Value above which damage should be dealt to the player
    /// </summary>
    /// <value></value>
    public float MagnitudeThreshold { get { return magnitudeThreshold; } }

    [Tooltip("Damage that should be dealt to the player")]
    [SerializeField]
    int damage = 0;

    /// <summary>
    /// Damage that should be dealt to the player
    /// </summary>
    /// <value></value>
    public int Damage { get { return damage; } }
}
