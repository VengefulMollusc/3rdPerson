using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMotor : Motor
{
    private float acceleration = 10f;
    private float deceleration = 10f;
    private float brakeRate = 10f;

    private bool throttle;
    private bool brake;

    private float currentSpeed = 0f;
    private float turnStrength;

    protected override void ApplyMove(Vector2 input)
    {
        turnStrength = input.x * Utilities.MapValues(currentSpeed, 0f, baseMoveSpeed, 0f, 1f);
    }

    void Update()
    {
        // update throttle speed
        if (throttle)
        {
            float diff = baseMoveSpeed - currentSpeed;
            currentSpeed += diff * acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;
            if (currentSpeed < 0f)
                currentSpeed = 0f;
        }

        if (brake)
        {
            turnStrength *= 2f;
            currentSpeed -= brakeRate * Time.deltaTime;
            if (currentSpeed < 0f)
                currentSpeed = 0f;
        }

        transform.position += transform.forward * currentSpeed * Time.deltaTime;
        Quaternion rot = Quaternion.AngleAxis(turnStrength * baseTurnSpeed * speedModifier * Time.deltaTime, Vector3.up);
        transform.rotation *= rot;
    }

    public override void UseDownAbility(bool _pressed)
    {
        throttle = _pressed;
    }

    public override void UseRightAbility(bool _pressed)
    {
        brake = _pressed;
    }
}
