using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeCost", menuName = "Shop/Upgrade Cost", order = 0)]
public class UpgradeCostSO : ScriptableObject
{
    [SerializeField]
    List<CountAndCost> costs = new List<CountAndCost>();

    /// <summary>
    /// Returns the cost of the next upgrade for an item based upon its count, or
    /// the highest cost of the upgrade, if the specific count is not found
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public uint GetCostForCount(uint count)
    {
        uint max = uint.MinValue;

        foreach (var cost in costs)
        {
            if (count == cost.Count)
            {
                return cost.Cost;
            }
            if (max < cost.Cost)
            {
                max = cost.Cost;
            }
        }

        return max;
    }

}
