using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    float rightYAngle = 0;

    [SerializeField]
    float leftYAngle = 0;

    [SerializeField]
    float upZAngle = 0;

    [SerializeField]
    float degreesPerSecondY = 0;

    [SerializeField]
    float degreesPerSecondZ = 0;

    [SerializeField]
    PlayerDirection left = null;

    [SerializeField]
    PlayerDirection right = null;

    [SerializeField]
    PlayerDirection up = null;

    [SerializeField]
    PlayerDirection down = null;

    PlayerDirection previousDirection = null;

    PlayerDirection currentDirectionHorizontal = null;

    public PlayerDirection CurrentDirectionHorizontal
    {
        set
        {

            currentDirectionHorizontal = value;
        }
    }

    PlayerDirection currentDirectionVertical;

    public PlayerDirection CurrentDirectionVertical
    {
        set
        {

            currentDirectionVertical = value;
        }
    }

    float targetY;
    float currentYSpeed;

    float targetZ;
    float currentZSpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetY = rightYAngle;
        targetZ = 0;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateZ();
        UpdateY();
    }



    void UpdateY()
    {
        if (currentDirectionHorizontal == left)
        {
            targetY = leftYAngle;
            currentYSpeed = degreesPerSecondY * Time.deltaTime;
        }
        else if (currentDirectionHorizontal == right)
        {
            targetY = rightYAngle;
            currentYSpeed = -degreesPerSecondY * Time.deltaTime;
        }


        float currentY = (transform.eulerAngles.y + 360) % 360;
        currentY = currentY > 180 ? currentY - 360 : currentY;
        var angles = transform.eulerAngles;

        if (Mathf.Sign(currentYSpeed) < 0)
        {
            angles.y = Mathf.Max(currentY + currentYSpeed, targetY);
        }
        else
        {
            angles.y = Mathf.Min(currentY + currentYSpeed, targetY);
        }
        //Debug.LogWarning(angles.y + " " + currentYSpeed);
        transform.eulerAngles = angles;
    }

    void UpdateZ()
    {
        if (currentDirectionVertical == up)
        {
            targetZ = upZAngle;
            currentZSpeed = degreesPerSecondZ * Time.deltaTime;
        }
        else if (currentDirectionVertical == down)
        {
            targetZ = -upZAngle;
            currentZSpeed = -degreesPerSecondZ * Time.deltaTime;
        }
        else
        {
            targetZ = 0;
        }

        float currentZ = (transform.eulerAngles.z + 360) % 360;
        currentZ = currentZ > 180 ? currentZ - 360 : currentZ;

        if (currentDirectionVertical != up && currentDirectionVertical != down)
        {
            currentZSpeed = (currentZ > 0 ? -1 : 1) * degreesPerSecondZ * Time.deltaTime;
        }

        var angles = transform.eulerAngles;
        if (Mathf.Sign(currentZSpeed) < 0)
        {
            angles.z = Mathf.Max(currentZ + currentZSpeed, targetZ);
        }
        else
        {
            angles.z = Mathf.Min(currentZ + currentZSpeed, targetZ);
        }
        transform.eulerAngles = angles;
    }
}
