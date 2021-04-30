using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    public UnityEvent OnPlayerDetected;

    public UnityEvent OnPlayerLeftArea;

    public void InvokeDetectionEvent()
    {
        OnPlayerDetected.Invoke();
    }

    public void InvokeLeavingEvent()
    {
        OnPlayerLeftArea.Invoke();
    }
}
