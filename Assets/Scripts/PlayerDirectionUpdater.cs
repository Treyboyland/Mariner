using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionUpdater : MonoBehaviour
{
    [SerializeField]
    PlayerDirection up = null;

    [SerializeField]
    PlayerDirection down = null;

    [SerializeField]
    PlayerDirection left = null;

    [SerializeField]
    PlayerDirection right = null;

    [SerializeField]
    PlayerDirection noneHorizontal = null;

    [SerializeField]
    PlayerDirection noneVertical = null;

    [SerializeField]
    PlayerDirection noneAll = null;

    [SerializeField]
    ParticleSystem ps;

    private void Update()
    {

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        bool isLeft, isRight, isUp, isDown;
        isLeft = isRight = isUp = isDown = false;


        if (vertical < 0)
        {
            isDown = true;
        }
        else if (vertical > 0)
        {
            isUp = true;
        }

        if (horizontal < 0)
        {
            isLeft = true;
        }
        else if (horizontal > 0)
        {
            isRight = true;
        }

        if (!(isLeft || isRight))
        {
            noneHorizontal.Invoke();
        }

        if (!(isUp || isDown))
        {
            noneVertical.Invoke();
        }

        if (!(isUp || isDown || isLeft || isRight))
        {
            noneAll.Invoke();
        }

        if (isLeft)
        {
            left.Invoke();
        }
        else if (isRight)
        {
            right.Invoke();
        }
        if (isUp)
        {
            up.Invoke();
        }
        else if (isDown)
        {
            down.Invoke();
        }
    }
}
