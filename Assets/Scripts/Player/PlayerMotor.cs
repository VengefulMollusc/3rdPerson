using System.Collections;
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

    public override void Move(Vector3 input)
    {
        inputVector = input;
    }

    public override void MoveCamera(float xMov, float yMov)
    {
        throw new System.NotImplementedException();
    }

    public override void Jump(bool pressed)
    {
        throw new System.NotImplementedException();
    }

    public override void Crouch(bool pressed)
    {
        throw new System.NotImplementedException();
    }
}
