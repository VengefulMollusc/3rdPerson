using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkerMotor : Motor
{
    private Vector3 facingVector;

    void Start()
    {
        facingVector = transform.forward;
    }

    protected override void ApplyMove(Vector2 input)
    {
        Vector3 inputVector = new Vector3(input.x, 0f, input.y);

        facingVector = Vector3.RotateTowards(facingVector, inputVector,
            baseTurnSpeed * speedModifier * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(facingVector);
        transform.position += inputVector * baseMoveSpeed * speedModifier * Time.deltaTime;
    }
}
