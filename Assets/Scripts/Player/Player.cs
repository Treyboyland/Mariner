using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerDataSO playerData = null;

    [SerializeField]
    GameEvent onFullHeal = null;

    [SerializeField]
    GameEvent onHealthUpdated = null;

    [SerializeField]
    GameEvent onPlayerDamaged = null;

    [SerializeField]
    GameEvent onPlayerDeath = null;

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

    private void Awake()
    {
        FullHeal();
    }

    public void FullHeal()
    {
        if (currentHealth != playerData.MaxHealth)
        {
            currentHealth = playerData.MaxHealth;
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
}
