using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class DropTableSO : ScriptableObject
{
    public abstract Pickup GetPickupForLocation(int x, int y);
}


public abstract class DropTableGenericSO<T> : ScriptableObject
{
    public abstract T GetDropForLocation(int x, int y);
}

public abstract class DropTableCurveGeneric<T> : DropTableGenericSO<T>
{
    [SerializeField]
    protected List<DropAndCurve<T>> drops = new List<DropAndCurve<T>>();

    public override T GetDropForLocation(int x, int y)
    {
        int probability = UnityEngine.Random.Range(0, 100);
        foreach (var drop in drops)
        {
            if (drop.Curve.Evaluate(y) >= probability)
            {
                return drop.Drop;
            }
        }

        return drops[0].Drop;
    }
}

[Serializable]
public class DropAndCurve<T>
{
    /// <summary>
    /// The drop that will be given
    /// </summary>
    [Tooltip("The drop that will be given")]
    public T Drop;

    /// <summary>
    /// Odds of receiving a drop at a particular depth
    /// </summary>
    [Tooltip("Odds of receiving a drop at a particular depth")]
    public AnimationCurve Curve;
}

[Serializable]
public class EnemyAndCurve : DropAndCurve<Enemy> { }