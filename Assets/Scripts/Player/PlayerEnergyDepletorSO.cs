using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerEnergyDepletion", menuName = "Player/Energy Depletion")]
public class PlayerEnergyDepletorSO : ScriptableObject
{
    [Tooltip("How much energy will be spent per second while moving")]
    [SerializeField]
    float movementEnergyPerSecond = 0;

    /// <summary>
    /// How much energy will be spent per second while moving
    /// </summary>
    /// <value></value>
    public float MovementEnergyPerSecond { get { return movementEnergyPerSecond; } }

    [Tooltip("How much energy will be spent per torpedo round")]
    [SerializeField]
    float energyPerTorpedoShot = 0;


    /// <summary>
    /// How much energy will be spent per torpedo round
    /// </summary>
    /// <value></value>
    public float EnergyPerTorpedoShot { get { return energyPerTorpedoShot; } }

}
