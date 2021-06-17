using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAtDepth : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite = null;

    [Tooltip("The depth past which there will be maximum darkrness")]
    [SerializeField]
    float maxDepth = 0;

    [SerializeField]
    PlayerDepth player = null;

    [SerializeField]
    AnimationCurve alphaCurve = null;

    [SerializeField]
    AnimationCurve nightAlphaCurve = null;

    [SerializeField]
    float darknessMaxAlpha;

    [SerializeField]
    DayNightCycle dayNightCycle = null;


    // Start is called before the first frame update
    void Start()
    {
        CheckDarkness();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDarkness();
    }

    void UpdateAlpha(float a)
    {
        if (a > 1)
        {
            a = 1;
        }
        var color = sprite.color;
        color.a = a;
        sprite.color = color;
    }

    public void CheckDarkness()
    {
        var depth = player.Depth;
        var progress = depth / maxDepth;
        UpdateAlpha(alphaCurve.Evaluate(progress) + darknessMaxAlpha * nightAlphaCurve.Evaluate(dayNightCycle.DayCyclePercentage));
    }
}
