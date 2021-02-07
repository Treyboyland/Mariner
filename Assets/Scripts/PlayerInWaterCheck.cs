using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInWaterCheck : MonoBehaviour
{
    [SerializeField]
    float distanceTop = 0;

    [SerializeField]
    float distanceBottom = 0;

    [SerializeField]
    Vector3 topOffset = new Vector2();

    [SerializeField]
    Vector3 bottomOffset = new Vector2();

    [SerializeField]
    GameEvent inWater = null;

    [SerializeField]
    GameEvent AtWaterLevel = null;

    [SerializeField]
    GameEvent OutOfWater = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var waterMask = LayerMask.GetMask("Game Water"); //
        var upCast = Physics2D.Raycast(transform.position + topOffset, Vector2.up, distanceTop, waterMask);
        var downCast = Physics2D.Raycast(transform.position + bottomOffset, -Vector2.up, distanceBottom, waterMask);

        Debug.DrawRay(transform.position + topOffset, Vector2.up * distanceTop, Color.red, 3);
        Debug.DrawRay(transform.position + bottomOffset, -Vector2.up * distanceBottom, Color.yellow, 3);


        if (upCast.collider != null && downCast.collider != null)
        {
            //Debug.LogWarning("In Water");
            inWater.Invoke();
        }
        else if (downCast.collider == null)
        {
            //Debug.LogWarning("Out of Water");
            OutOfWater.Invoke();
        }
        else
        {
            //Debug.LogWarning("At water level");
            AtWaterLevel.Invoke();
        }
    }
}
