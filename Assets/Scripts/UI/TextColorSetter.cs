using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorSetter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text = null;

    [SerializeField]
    List<Color> colors = new List<Color>();


    public void SetColor(int index)
    {
        if (index < colors.Count)
        {
            text.faceColor = colors[index];
        }
    }
}
