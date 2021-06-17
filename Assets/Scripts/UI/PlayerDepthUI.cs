using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDepthUI : MonoBehaviour
{
    [SerializeField]
    PlayerDepth playerDepth = null;

    [SerializeField]
    Player player = null;

    [SerializeField]
    TextMeshProUGUI textBox = null;

    [SerializeField]
    float cautionThreshold = .75f;

    [SerializeField]
    Color cautionColor = Color.yellow;

    [SerializeField]
    Color dangerColor = Color.red;

    [SerializeField]
    Color normalColor = Color.white;

    [SerializeField]
    GameEvent startDamageEvent = null;

    [SerializeField]
    GameEvent stopDamageEvent = null;

    public void UpdateDepth()
    {
        textBox.text = "Depth: " + GetDepthString() + "m";
        textBox.faceColor = GetColor();
        CheckForDamageEvent();
    }

    void CheckForDamageEvent()
    {
        if (playerDepth.Depth >= player.Data.MaxDepth)
        {
            startDamageEvent.Invoke();
        }
        else
        {
            stopDamageEvent.Invoke();
        }
    }

    Color GetColor()
    {
        if (playerDepth.Depth >= player.Data.MaxDepth)
        {
            return dangerColor;
        }
        if (playerDepth.Depth >= player.Data.MaxDepth - cautionThreshold)
        {
            return cautionColor;
        }
        return normalColor;
    }

    string GetDepthString()
    {
        return System.Math.Round((playerDepth.Depth), 1).ToString("N1");
    }
}
