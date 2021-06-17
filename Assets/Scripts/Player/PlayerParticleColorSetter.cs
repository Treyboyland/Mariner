using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleColorSetter : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle = null;

    public void SetMainColor(Color frontColor, Color backColor)
    {
        var main = particle.main;
        var startColor = main.startColor;
        var colorGradient = startColor.gradient;
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[] {
            new GradientAlphaKey(1,0),
            new GradientAlphaKey(1,1)
        };
        GradientColorKey[] colorKeys = new GradientColorKey[] {
            new GradientColorKey(frontColor, 0.5f),
            new GradientColorKey(backColor, 1f),
        };
        colorGradient.SetKeys(colorKeys, alphaKeys);
        startColor.gradient = colorGradient;
        main.startColor = startColor;
    }
}
