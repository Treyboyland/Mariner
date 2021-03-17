using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipColorSlider : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    GameEvent valueChangedEvent;

    public bool SendEvent { get; set; } = false;

    public float Value
    {
        get
        {
            return (slider.value - slider.minValue) / (slider.maxValue - slider.minValue);
        }
        set
        {
            slider.value = (slider.maxValue - slider.minValue) * value + slider.minValue;
        }
    }

    public void FireEvent()
    {
        if (SendEvent)
        {
            valueChangedEvent.Invoke();
        }
    }

}
