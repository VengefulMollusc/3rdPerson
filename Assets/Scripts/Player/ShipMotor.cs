using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMotor : Motor
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float turnSpeed = 1f;
    private const float turnMoveSpeedMod = 0.75f;

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
        transform.position += transform.forward * moveSpeed * currentThrottle * Time.deltaTime;

        float yawStrength = currentYawStrength * turnSpeed * Time.deltaTime *
                            Utilities.MapValues(Mathf.Abs(currentThrottle), 0f, 1f, 1f, turnMoveSpeedMod);
        transform.rotation *= Quaternion.AngleAxis(yawStrength, Vector3.up);

        Debug.Log(currentThrottle + " " + yawStrength);
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
