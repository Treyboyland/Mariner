using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    GameEvent gameEvent = null;

    public UnityEvent Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }


}
