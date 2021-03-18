using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CountTable", menuName = "Misc/Count Table", order = 0)]
public class CountTableSO : ScriptableObject
{
    [SerializeField]
    List<CountAndValue> costs = new List<CountAndValue>();

    /// <summary>
    /// Returns the value of *something* based upon its count, or
    /// the highest possible value, if the specific count is not found
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public float GetCostForCount(uint count)
    {
        float max = float.MinValue;

        foreach (var cost in costs)
        {
            if (count == cost.Count)
            {
                return cost.Value;
            }
            if (max < cost.Count)
            {
                max = cost.Value;
            }
        }

        return max;
    }
}
