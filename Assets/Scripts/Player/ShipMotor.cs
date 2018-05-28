using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMotor : Motor
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float turnSpeed = 1f;

    [SerializeField] private float throttleAdjustSpeed = 0.1f;
    [SerializeField] private float yawAdjustSpeed = 0.1f;

    private const float reverseSpeed = 0.5f;

    private float currentThrottle;
    private float currentYawStrength;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
        rb.rotation *= Quaternion.AngleAxis(currentYawStrength * turnSpeed * Time.deltaTime, Vector3.up);
    }

    public override void Move(float xMov, float yMov)
    {
        AdjustThrottle(yMov);
        AdjustYaw(xMov);
    }

    void AdjustThrottle(float adjustVal)
    {
        currentThrottle += (adjustVal * throttleAdjustSpeed);
        currentThrottle = Mathf.Clamp(currentThrottle, reverseSpeed, 1f);
    }

    void AdjustYaw(float adjustVal)
    {
        currentYawStrength += (adjustVal * yawAdjustSpeed);
        currentYawStrength = Mathf.Clamp(currentYawStrength, -1f, 1f);
    }
}
