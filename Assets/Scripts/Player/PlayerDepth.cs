using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDepth : MonoBehaviour
{
    [SerializeField]
    GameEvent depthEvent = null;

    /// <summary>
    /// Player's current depth
    /// </summary>
    /// <value></value>
    public float Depth { get { return -transform.position.y  * 10; } }

    // Update is called once per frame
    void Update()
    {
        depthEvent.Invoke();
    }
}
