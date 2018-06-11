using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMotor : Motor
{
    private const float throttleAdjustSpeed = 1f;

    private const float reverseSpeed = -0.5f;

    private float throttleState;

    private float currentSpeed;
    private float currentTurnSpeed;

    public override void Move(Vector2 input)
    {
        AdjustThrottle(input.y);
        transform.position += transform.forward * currentSpeed * speedModifier;

        AdjustTurn(input.x);
        Quaternion rot = Quaternion.AngleAxis(currentTurnSpeed * speedModifier * Time.deltaTime, Vector3.up);
        transform.rotation *= rot;
    }

    // Updates throttle control state
    void AdjustThrottle(float adjustVal)
    {
        throttleState += adjustVal * throttleAdjustSpeed * Time.deltaTime;
        throttleState = Mathf.Clamp(throttleState, reverseSpeed, 1f);
        currentSpeed = throttleState * baseMoveSpeed * Time.deltaTime;
    }

    // Updates turn control state
    void AdjustTurn(float adjustVal)
    {
        float newTurnSpeed = adjustVal * baseTurnSpeed;



        currentTurnSpeed = newTurnSpeed;
    }
}
