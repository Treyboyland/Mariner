using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "Shop/Color", order = 1)]
public class ColorSO : ScriptableObject
{
    [Tooltip("Display name for this color")]
    [SerializeField]
    string colorName = "";

    /// <summary>
    /// Display name for this color
    /// </summary>
    /// <value></value>
    public string ColorName { get { return colorName; } }

    [Tooltip("Color Value")]
    [SerializeField]
    Color color = Color.black;

    /// <summary>
    /// Color Value
    /// </summary>
    /// <value></value>
    public Color Color { get { return color; } }

}
