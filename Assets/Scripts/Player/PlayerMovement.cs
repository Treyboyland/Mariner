﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    ItemDataSO mysteriousItem;

    [SerializeField]
    float speed = 0;

    [SerializeField]
    bool isInWater = false;

    public bool IsInWater
    {
        get
        {
            return isInWater;
        }
        set
        {
            isInWater = value;
        }
    }

    [SerializeField]
    bool canMove = true;

    public bool CanMove
    {
        get
        {
            return canMove;
        }
        set
        {
            canMove = value;
        }
    }

    public bool IsMoving { get; private set; } = false;

    [SerializeField]
    Rigidbody2D body = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        var y = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

        IsMoving = Input.GetButton("Movement");

        body.AddForce(new Vector2(x, isInWater || player.Data.CurrentInventory.HasItem(mysteriousItem) ? y : 0), ForceMode2D.Impulse);
    }

    public void Stop()
    {
        body.velocity = new Vector2();
        body.angularVelocity = 0;
    }
}
