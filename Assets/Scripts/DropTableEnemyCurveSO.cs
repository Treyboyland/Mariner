using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropTableEnemyCurve", menuName = "Drop Table/Enemy Curve", order = 1)]
public class DropTableEnemyCurveSO : DropTableCurveGeneric<Enemy>
{
    [SerializeField]
    new List<EnemyAndCurve> drops = new List<EnemyAndCurve>();

    public override Enemy GetDropForLocation(int x, int y)
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
