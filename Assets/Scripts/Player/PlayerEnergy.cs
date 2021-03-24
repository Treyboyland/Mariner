using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    PlayerMovement movement = null;

    [SerializeField]
    PlayerEnergyDepletorSO energySettings = null;


    private void FixedUpdate()
    {
        //Doing this because movement is also updated during fixed update
        if (movement.IsMoving)
        {
            //Debug.LogWarning(gameObject.name + ": Current energy: " + player.CurrentEnergy);
            player.TakeEnergy(energySettings.MovementEnergyPerSecond * Time.fixedDeltaTime);
        }
    }
}
