﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float moveSpeed = 2;
    public float thrust = .5f;
    public bool canMove;
    private float rightAxis;
    private float upAxis;
    private float changeSpeed;
    private Vector2 velocity;

    protected void Awake()
    {
        velocity = Vector2.zero;
        changeSpeed = moveSpeed / thrust;
    }

    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rightAxis = Input.GetAxis("Horizontal");
            upAxis = Input.GetAxis("Vertical") * .75f;
            UpdateMove();
        }
    }

    void UpdateMove()
    {
        Vector2 axisDirection   = new Vector2(rightAxis, upAxis);
        Vector2 currentVelocity = velocity;
        Vector2 desiredVelocity = axisDirection * moveSpeed;

        if (axisDirection == Vector2.zero)
        {
            desiredVelocity = Vector2.zero;
        }

        float velociyBoost = 2f - Vector2.Dot(currentVelocity.normalized, desiredVelocity.normalized);
        currentVelocity = Vector2.MoveTowards(currentVelocity, desiredVelocity, changeSpeed);

        Vector2 velocityChange = desiredVelocity * Time.deltaTime;
        transform.position += new Vector3(velocityChange.x, velocityChange.y, 0);
    }
}