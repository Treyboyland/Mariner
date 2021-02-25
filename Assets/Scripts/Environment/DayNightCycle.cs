using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    Gradient skyColor = null;

    [SerializeField]
    Camera mainCamera = null;

    [SerializeField]
    GameEvent onDayStarted = null;

    [SerializeField]
    GameEvent onNightStarted = null;

    [SerializeField]
    float secondsPerCycle = 0;

    [SerializeField]
    Vector2 nightPercentage = new Vector2();

    [SerializeField]
    float elapsed = 0;

    /// <summary>
    /// True if we have moved to night
    /// </summary>
    bool isNight = false;

    /// <summary>
    /// True if we have moved to night
    /// </summary>
    /// <value></value>
    public bool IsNight { get { return isNight; } set { isNight = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed = (elapsed + Time.deltaTime) % secondsPerCycle;
        var progress = elapsed / secondsPerCycle;
        mainCamera.backgroundColor = skyColor.Evaluate(progress);
        if (!isNight && progress >= nightPercentage.x && progress <= nightPercentage.y)
        {
            Debug.LogWarning("Night");
            onNightStarted.Invoke();
        }
        else if (isNight && (progress < nightPercentage.x || progress > nightPercentage.y))
        {
            Debug.LogWarning("Day");
            onDayStarted.Invoke();
        }
    }
}
