using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHullUI : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    TextMeshProUGUI textBox = null;

    // Start is called before the first frame update
    void Start()
    {
        SetHullString();
    }

    public void SetHullString()
    {
        textBox.text = "Hull: " + player.CurrentHealth + " / " + player.Data.MaxHealth;
    }
}
