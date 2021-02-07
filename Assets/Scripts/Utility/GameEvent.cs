using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Normal Event", order = -1)]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            listener.Response.Invoke();
        }
    }

    public void AddListener(GameEventListener newListener)
    {
        if (!listeners.Contains(newListener)) //Prevent double calls...hopefully
        {
            listeners.Add(newListener);
        }
    }

    public void RemoveListener(GameEventListener toRemove)
    {
        listeners.Remove(toRemove);
    }

}
