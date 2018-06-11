using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MechMotor : Motor
{
    private float baseMoveSpeed = 4f;
    private float baseTurnSpeed = 2f;
    private const float boostFactor = 1.5f;

    private Vector3 movementVector;
    private Vector3 facingVector;

    // boost variables
    private bool boosting;

    void Start()
    {
        facingVector = transform.forward;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(facingVector);
        transform.position += movementVector;
    }

    public override void Move(Vector2 input)
    {
        Vector3 inputVector = new Vector3(input.x, 0f, input.y) * Time.deltaTime;

        if (boosting)
        {
            inputVector *= boostFactor;
            facingVector = Vector3.RotateTowards(facingVector, inputVector,
                baseTurnSpeed * boostFactor * Time.deltaTime, 0);
        }
        else
        {
            facingVector = Vector3.RotateTowards(facingVector, inputVector, 
                baseTurnSpeed * Time.deltaTime, 0);
        }

        movementVector = inputVector * baseMoveSpeed;
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
}
