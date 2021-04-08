using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [Tooltip("Time of last save")]
    [SerializeField]
    long saveTime = 0;

    /// <summary>
    /// Time of last save;
    /// </summary>
    /// <value></value>
    public DateTime SaveTime
    {
        get
        {
            return new DateTime(saveTime);
        }
        set
        {
            saveTime = value.Ticks;
        }
    }

    [Tooltip("The player's maximum health points")]
    [SerializeField]
    int maxHealth = 0;

    /// <summary>
    /// The player's maximum health points
    /// </summary>
    public int MaxHealth { get { return maxHealth; } }

    [Tooltip("Current items the player has")]
    [SerializeField]
    InventorySO currentInventory = null;

    /// <summary>
    /// Current items the player has
    /// </summary>
    /// <value></value>
    public InventorySO CurrentInventory { get { return currentInventory; } }

    [Tooltip("The depth at which the player will start taking damage")]
    [SerializeField]
    float maxDepth = 0;

    [Tooltip("Maximum amount of energy that the player has")]
    [SerializeField]
    float maxEnergy;

    /// <summary>
    /// Maximum amount of energy that the player has
    /// </summary>
    /// <value></value>
    public float MaxEnergy
    {
        get
        {
            return maxEnergy;
        }
        set
        {
            maxEnergy = value;
        }
    }

    [Tooltip("Color of the ship on the back")]
    [SerializeField]
    Color backColor;

    /// <summary>
    /// Color of the ship on the back
    /// </summary>
    /// <value></value>
    public Color BackColor
    {
        get
        {
            return backColor;
        }
        set
        {
            backColor = value;
        }
    }

    [Tooltip("Color of the ship on the front")]
    [SerializeField]
    Color frontColor;

    /// <summary>
    /// Color of the ship on the front
    /// </summary>
    /// <value></value>
    public Color FrontColor
    {
        get
        {
            return frontColor;
        }
        set
        {
            frontColor = value;
        }
    }

    /// <summary>
    /// The depth at which the player will start taking damage
    /// </summary>
    /// <value></value>
    public float MaxDepth { get { return maxDepth; } set { maxDepth = value; } }

    public PlayerDataSO Copy()
    {
        //TODO: Modify this to use reflection...
        PlayerDataSO toReturn = ScriptableObject.CreateInstance<PlayerDataSO>();
        toReturn.maxHealth = this.maxHealth;
        toReturn.maxDepth = this.maxDepth;
        toReturn.currentInventory = this.currentInventory.Copy();
        toReturn.backColor = this.backColor;
        toReturn.frontColor = this.frontColor;
        toReturn.maxEnergy = this.maxEnergy;
        toReturn.saveTime = this.saveTime;


        return toReturn;
    }

    public void SetData(PlayerDataSO other)
    {
        this.maxHealth = other.maxHealth;
        this.maxDepth = other.maxDepth;
        this.currentInventory = other.currentInventory.Copy();
        this.backColor = other.backColor;
        this.frontColor = other.frontColor;
        this.maxEnergy = other.maxEnergy;
        this.saveTime = other.saveTime;
    }
}
