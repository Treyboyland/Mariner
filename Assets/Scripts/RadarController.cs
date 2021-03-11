using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarController : MonoBehaviour
{
    [SerializeField]
    GameEvent onStartRadar = null;

    [SerializeField]
    GameEvent onStopRadar = null;

    [SerializeField]
    GameObject radarImage = null;

    public bool CanUseRadar { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        radarImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanUseRadar && Input.GetButtonDown("Radar"))
        {
            FireEvent();
        }
    }

    void FireEvent()
    {
        if (radarImage.gameObject.activeInHierarchy)
        {
            onStopRadar.Invoke();
        }
        else
        {
            onStartRadar.Invoke();
        }
    }
}
