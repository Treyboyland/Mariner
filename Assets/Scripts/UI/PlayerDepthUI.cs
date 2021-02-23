using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDepthUI : MonoBehaviour
{
    [SerializeField]
    PlayerDepth player = null;

    [SerializeField]
    TextMeshProUGUI textBox;

    public void UpdateDepth()
    {
        textBox.text = "Depth: " + GetDepthString() + "m";
    }

    string GetDepthString()
    {

        return System.Math.Round((player.Depth * 10), 1).ToString("N1");
    }
}
