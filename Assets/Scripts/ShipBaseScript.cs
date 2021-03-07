using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBaseScript : MonoBehaviour
{
    [SerializeField]
    GameEvent playerEnteredBase = null;

    [SerializeField]
    GameEvent playerExitedBase = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            playerExitedBase.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            playerEnteredBase.Invoke();
        }
    }
}
