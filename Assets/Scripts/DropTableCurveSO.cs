using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DropTableCurve", menuName = "Pickup/Drop Table/Curve", order = 2)]
public class DropTableCurveSO : DropTableSO
{
    [SerializeField]
    List<DropAndCurve> drops = new List<DropAndCurve>();

    public override Pickup GetPickupForLocation(int x, int y)
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

    [Serializable]
    public struct DropAndCurve
    {
        /// <summary>
        /// The drop that will be given
        /// </summary>
        [Tooltip("The drop that will be given")]
        public Pickup Drop;

        /// <summary>
        /// Odds of receiving a drop at a particular depth
        /// </summary>
        [Tooltip("Odds of receiving a drop at a particular depth")]
        public AnimationCurve Curve;
    }
}
