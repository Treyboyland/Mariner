using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField]
    GamePauser pauser = null;

    private void OnEnable()
    {
        if (!pauser.GamePaused)
        {
            gameObject.SetActive(false);
        }
    }
}
