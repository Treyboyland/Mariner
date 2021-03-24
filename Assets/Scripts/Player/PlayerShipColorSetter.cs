using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipColorSetter : MonoBehaviour
{

    [SerializeField]
    Player player = null;

    [SerializeField]
    List<SpriteRenderer> frontSprites = null;

    [SerializeField]
    List<SpriteRenderer> backSprites = null;

    // Start is called before the first frame update
    void Start()
    {
        SetColors();
    }


    public void SetColors()
    {
        SetColors(frontSprites, player.Data.FrontColor);
        SetColors(backSprites, player.Data.BackColor);
    }

    void SetColors(List<SpriteRenderer> renderers, Color color)
    {
        foreach (var renderer in renderers)
        {
            renderer.color = color;
        }
    }
}
