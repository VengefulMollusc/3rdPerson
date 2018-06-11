using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LightMechMotor : Motor
{
    public override void Move(Vector2 input)
    {
        Vector3 movementDirection = new Vector3(input.x, 0f, input.y) * baseMoveSpeed * speedModifier * Time.deltaTime;
        transform.position += movementDirection;
        transform.rotation = Quaternion.LookRotation(movementDirection);
    }
}
