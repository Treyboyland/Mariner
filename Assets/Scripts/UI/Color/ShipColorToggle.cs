using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipColorToggle : MonoBehaviour
{
    [SerializeField]
    Toggle toggle = null;

    [SerializeField]
    GameEvent gameEvent = null;

    public Toggle Toggle
    {
        get
        {
            return toggle;
        }
    }

    public bool SendEvent { get; set; } = false;

    public void FireEvent()
    {
        if (SendEvent)
        {
            gameEvent.Invoke();
        }
    }
}
