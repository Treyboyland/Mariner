using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClaw : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    SpriteRenderer clawBody = null;

    [SerializeField]
    GameEventGameObject onTreasureClose = null;

    [SerializeField]
    GameEventGameObject onTreasureExited = null;

    [SerializeField]
    float yGrowthSpeed = 0;

    [SerializeField]
    float yShrinkSpeed = 0;

    [SerializeField]
    float initialLength = 0;

    bool movingTowardsTreasure = false;

    GameObject currentTreasureTracked;

    // Start is called before the first frame update
    void Start()
    {
        SetYScale(initialLength);
        SetAlpha(0);
    }

    private void OnDisable()
    {
        ResetClaw();
    }

    void SetAlpha(float alpha)
    {
        var color = clawBody.color;
        color.a = alpha;
        clawBody.color = color;
    }

    void ResetClaw()
    {
        movingTowardsTreasure = false;
        currentTreasureTracked = null;
        SetYScale(initialLength);
        StopAllCoroutines();
        SetAlpha(0);
    }

    public void StopTracking()
    {
        if (currentTreasureTracked == onTreasureExited.GameObject)
        {
            currentTreasureTracked = null;
        }
    }

    public void StartTracking()
    {
        if (!movingTowardsTreasure && gameObject.activeInHierarchy)
        {
            currentTreasureTracked = onTreasureClose.GameObject;
            SetAlpha(1);
            StartCoroutine(GrowTowardsObject());
        }
    }

    void SetYScale(float val)
    {
        var localScale = transform.localScale;
        localScale.y = val;
        transform.localScale = localScale;
    }

    IEnumerator GrowTowardsObject()
    {
        movingTowardsTreasure = true;

        SetYScale(initialLength);

        //Grow Towards
        while (currentTreasureTracked != null && currentTreasureTracked.gameObject.activeInHierarchy)
        {
            float angle = Vector3.Angle(currentTreasureTracked.transform.position - transform.position, Vector3.down);
            if (transform.position.x > currentTreasureTracked.transform.position.x)
            {
                //For some reason, we need to flip this if we are ahead of the coin
                angle *= -1;
            }
            //angle = angle < 90 ? angle - 180 : angle;// (angle + 360) % 360;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            SetYScale(transform.localScale.y + Time.deltaTime * yGrowthSpeed);
            yield return null;
        }

        //Retract
        while (transform.localScale.y > initialLength)
        {
            SetYScale(Mathf.Max(initialLength, transform.localScale.y - Time.deltaTime * yShrinkSpeed));
            yield return null;
        }

        SetYScale(initialLength);
        SetAlpha(0);
        movingTowardsTreasure = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var pickup = other.GetComponent<Pickup>();
        if (pickup != null)
        {
            pickup.AddPickupToPlayer(player);
        }
    }
}
