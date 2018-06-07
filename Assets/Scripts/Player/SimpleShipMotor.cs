using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleShipMotor : Motor
{
    [SerializeField]
    private float baseMoveSpeed = 5f; // 5f

    [SerializeField]
    private float baseTurnSpeed = 20f; // 20f

    private Vector3 movementVector;

    // boost variables
    private bool boosting;
    private const float boostFactor = 2f;

    public override void Move(Vector2 inputVector)
    {
        Vector3 input = new Vector3(inputVector.x, 0f, inputVector.y) * Time.deltaTime;

        if (boosting)
            input *= boostFactor;

        movementVector = input * baseMoveSpeed;
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
        transform.rotation = Quaternion.LookRotation(movementVector);
        transform.position += movementVector;
    }
}
