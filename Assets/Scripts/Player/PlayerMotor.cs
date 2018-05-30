﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : Motor
{
    [SerializeField] private float movementSpeed = 1f;

    private Rigidbody rb;

    private Vector3 inputVector;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (inputVector == Vector3.zero)
            return;
        
        rb.velocity = inputVector * movementSpeed;
    }

    public override void Move(float xMov, float yMov)
    {
        inputVector = new Vector3(xMov, 0f, yMov); ;
    }

    public override void Boost(bool pressed)
    {
        throw new System.NotImplementedException();
    }
}
