using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MechMotor : Motor
{
    private Vector3 facingVector;

    void Start()
    {
        facingVector = transform.forward;
    }

    public override void Move(Vector2 input)
    {
        Vector3 inputVector = new Vector3(input.x, 0f, input.y) * Time.deltaTime;

        if (!speedModifier.Equals(1f))
        {
            inputVector *= speedModifier;
            facingVector = Vector3.RotateTowards(facingVector, inputVector,
                baseTurnSpeed * speedModifier * Time.deltaTime, 0);
        }
        else
        {
            facingVector = Vector3.RotateTowards(facingVector, inputVector, 
                baseTurnSpeed * Time.deltaTime, 0);
        }

        transform.rotation = Quaternion.LookRotation(facingVector);
        transform.position += inputVector * baseMoveSpeed;
    }
}
