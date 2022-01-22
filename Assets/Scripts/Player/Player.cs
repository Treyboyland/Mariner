using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO playerData = null;

    [SerializeField]
    bool isDebug = false;

    [SerializeField]
    PlayerDataSO debugData = null;

    [SerializeField]
    PlayerDataSO releaseData = null;

    [Header("Health Events")]

    [SerializeField]
    GameEvent onFullHeal = null;

    [SerializeField]
    GameEvent onHealthUpdated = null;

    [SerializeField]
    GameEvent onPlayerDamaged = null;

    [SerializeField]
    GameEvent onPlayerDeath = null;

    [Header("Energy Events")]
    [SerializeField]
    GameEvent onEnergyUpdated = null;


    public PlayerDataSO Data
    {
        get
        {
            return playerData;
        }
    }

    int currentHealth;

    /// <summary>
    /// Current health of the player
    /// </summary>
    /// <value></value>
    public int CurrentHealth { get { return currentHealth; } }

    [SerializeField]
    float currentEnergy;

    public float CurrentEnergy { get { return currentEnergy; } }

    private void Awake()
    {
        if (isDebug)
        {
            Debug.LogWarning("Debug Mode. Loading " + debugData);
            playerData = debugData.Copy();
        }
        else
        {
            Debug.LogWarning("Release Mode. Loading " + releaseData);
            playerData = releaseData.Copy();
        }
        FullHeal();
    }

    public void FullHeal()
    {
        bool healthChanged = currentHealth != playerData.MaxHealth;
        bool energyChanged = currentEnergy != playerData.MaxEnergy;

        if (currentHealth != playerData.MaxHealth)
        {
            currentHealth = playerData.MaxHealth;
        }

        if (currentEnergy != playerData.MaxEnergy)
        {
            currentEnergy = playerData.MaxEnergy;
            onEnergyUpdated.Invoke();
        }

        if (healthChanged || energyChanged)
        {
            onFullHeal.Invoke();
        }

        onHealthUpdated.Invoke();
    }

    public void TakeDamage(int damage)
    {
        var originalHealth = currentHealth;
        currentHealth = Mathf.Max(0, currentHealth - damage);

        if (originalHealth != currentHealth)
        {
            onHealthUpdated.Invoke();
        }

        onPlayerDamaged.Invoke();

        if (currentHealth == 0)
        {
            onPlayerDeath.Invoke();
        }
    }

    public void InstaKill()
    {
        TakeDamage(currentHealth);
    }

    public void TakeEnergy(float energytoTake)
    {
        var originalEnergy = currentEnergy;
        currentEnergy = Mathf.Max(0, currentEnergy - energytoTake);

        if (currentEnergy != originalEnergy)
        {
            onEnergyUpdated.Invoke();
        }
    }

    public void AddEnergy(float energyToAdd)
    {
        var originalEnergy = currentEnergy;
        currentEnergy = Mathf.Min(Data.MaxEnergy, currentEnergy + energyToAdd);

        if (currentEnergy != originalEnergy)
        {
            onEnergyUpdated.Invoke();
        }
    }
}
