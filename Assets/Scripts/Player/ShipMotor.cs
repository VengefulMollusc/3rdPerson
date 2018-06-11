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

    //private float changeThrottle;

    public override void Move(Vector2 input)
    {
        //AdjustThrottle(changeThrottle);
        AdjustThrottle(input.y);

        currentTurnSpeed = input.x * baseTurnSpeed;
    }

    void Update()
    {
        transform.position += transform.forward * currentSpeed * speedModifier;
        Quaternion rot = Quaternion.AngleAxis(currentTurnSpeed * speedModifier * Time.deltaTime, Vector3.up);
        transform.rotation *= rot;
    }

    // Override abilities with throttle controls
    //public override void UseUpAbility(bool pressed)
    //{
    //    changeThrottle = pressed ? 1f : 0f;
    //}

    //public override void UseDownAbility(bool pressed)
    //{
    //    changeThrottle = pressed ? -1f : 0f;
    //}

    // Updates throttle control state
    void AdjustThrottle(float adjustVal)
    {
        throttleState += adjustVal * throttleAdjustSpeed * Time.deltaTime;
        throttleState = Mathf.Clamp(throttleState, reverseSpeed, 1f);
        currentSpeed = throttleState * baseMoveSpeed * Time.deltaTime;
    }
}
