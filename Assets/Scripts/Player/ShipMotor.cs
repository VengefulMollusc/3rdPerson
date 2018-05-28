using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMotor : Motor
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float turnSpeed = 1f;

    [SerializeField] private float throttleAdjustSpeed = 1f;
    [SerializeField] private float yawAdjustSpeed = 1f;

    private const float reverseSpeed = -0.5f;

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
        Debug.Log(currentThrottle + " " + currentYawStrength);
        transform.position += transform.forward * moveSpeed * currentThrottle * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(currentYawStrength * turnSpeed * Time.deltaTime, Vector3.up);
    }

    public override void Move(float xMov, float yMov)
    {
        AdjustThrottle(yMov);
        AdjustYaw(xMov);
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
