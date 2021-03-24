using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerEnergyUI : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    TextMeshProUGUI textBox = null;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        //Debug.LogWarning("Current Energy: " + player.CurrentEnergy + " Max Energy: " + player.Data.MaxEnergy);
        textBox.text = "Energy: " + Math.Round((player.CurrentEnergy / player.Data.MaxEnergy) * 100, 1).ToString(".0") + "%";
    }
}
