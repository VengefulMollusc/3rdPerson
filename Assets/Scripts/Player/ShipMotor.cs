using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMotor : Motor
{
    private float moveSpeed = 1f;
    private float turnSpeed = 10f;
    private const float turnMoveSpeedMod = 0.75f;

    private float throttleAdjustSpeed = 1f;
    private float yawAdjustSpeed = 1f;

    private const float accelerationRate = 0.01f;

    private float currentSpeed;

    private const float reverseSpeed = -0.5f;

    private float currentThrottle;
    private float currentYawStrength;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Move(float xMov, float yMov)
    {
        AdjustThrottle(yMov);
        AdjustYaw(xMov);
    }

    void Update()
    {
        UpdateSpeed();
        transform.position += transform.forward * currentSpeed;

        float yawStrength = currentYawStrength * turnSpeed * Time.deltaTime *
                            Utilities.MapValues(Mathf.Abs(currentThrottle), 0f, 1f, 1f, turnMoveSpeedMod);
        transform.rotation *= Quaternion.AngleAxis(yawStrength, Vector3.up);

        Debug.Log(currentThrottle.ToString("F2") + " " + currentYawStrength.ToString("F2") + " : " + (currentSpeed / Time.deltaTime).ToString("F2") + " " + (yawStrength / Time.deltaTime).ToString("F2"));
    }

    void UpdateSpeed()
    {
        float throttleSpeed = moveSpeed * currentThrottle * Time.deltaTime;

        float diff = throttleSpeed - currentSpeed;

        currentSpeed += diff * accelerationRate;
    }

    void AdjustThrottle(float adjustVal)
    {
        currentThrottle += adjustVal * throttleAdjustSpeed * Time.deltaTime;
        currentThrottle = Mathf.Clamp(currentThrottle, reverseSpeed, 1f);
    }

    void AdjustYaw(float adjustVal)
    {
        currentYawStrength += adjustVal * yawAdjustSpeed * Time.deltaTime;
        currentYawStrength = Mathf.Clamp(currentYawStrength, -1f, 1f);
    }
}
