using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleShipMotor : Motor
{
    [SerializeField]
    private float baseMoveSpeed = 5f; // 5f
    private float baseTurnSpeed = 2f; // 20f

    private float acceleration = 1f;

    private Vector3 movementVector;
    private Vector3 facingVector;

    // boost variables
    private bool boosting;
    private const float boostFactor = 2f;

    void Start()
    {
        facingVector = transform.forward;
    }

    public override void Move(Vector2 inputVector)
    {
        Vector3 input = new Vector3(inputVector.x, 0f, inputVector.y) * Time.deltaTime;

        if (boosting)
            input *= boostFactor;

        Vector3 newMovementVector = input * baseMoveSpeed;
        movementVector = Vector3.RotateTowards(movementVector, newMovementVector, baseTurnSpeed * Time.deltaTime, acceleration * Time.deltaTime);

        if (movementVector != Vector3.zero)
            facingVector = movementVector.normalized;
    }

    public override void UseUpAbility(bool pressed)
    {
        Debug.Log("Fire Forward");
    }

    public override void UseDownAbility(bool pressed)
    {
        boosting = pressed;
    }

    public override void UseLeftAbility(bool pressed)
    {
        Debug.Log("Fire Left");
    }

    public override void UseRightAbility(bool pressed)
    {
        Debug.Log("Fire Right");
    }

    void Update()
    {
        Debug.Log(movementVector);
        transform.rotation = Quaternion.LookRotation(facingVector);
        transform.position += movementVector;
    }
}
