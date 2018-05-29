using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMotor : Motor
{
    [SerializeField]
    private float baseMoveSpeed = 1f; // 1f

    [SerializeField]
    private float baseTurnSpeed = 20f; // 20f

    private const float moveSpeedTurnMod = 0.5f;
    private const float turnMoveSpeedMod = 0.75f;

    private const float throttleAdjustSpeed = 1f;
    private const float yawAdjustSpeed = 1f;

    private const float accelerationRate = 1f; // 0.01
    //private const float decelerationRate = 0.01f;

    private const float reverseSpeed = -0.5f;

    private float throttleState;
    private float yawControlState;

    private float currentSpeed;
    private float currentTurnSpeed;

    //private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
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

        UpdateTurn();
        Quaternion rot = Quaternion.AngleAxis(currentTurnSpeed, Vector3.up);
        transform.rotation *= rot;

        // Debugging
        int stepSize = 10;
        Vector3 projectedVector = transform.forward * currentSpeed * stepSize;
        Vector3 startPos = transform.position;
        rot = Quaternion.AngleAxis(currentTurnSpeed * stepSize, Vector3.up);
        for (int i = 0; i < 100; i++)
        {
            Debug.DrawLine(startPos, startPos + projectedVector, Color.green, 0.2f);
            startPos += projectedVector;
            projectedVector = rot * projectedVector;
        }
        Debug.DrawLine(transform.position, transform.position + transform.forward * 10f, Color.cyan, 0.2f);
        Debug.Log(throttleState.ToString("F2") + " " + yawControlState.ToString("F2") + " : " + (currentSpeed / Time.deltaTime).ToString("F2") + " " + (currentTurnSpeed / Time.deltaTime).ToString("F2"));
    }

    void UpdateSpeed()
    {
        float targetSpeed = throttleState * baseMoveSpeed * Time.deltaTime * 
            Utilities.MapValues(Mathf.Abs(currentTurnSpeed * currentTurnSpeed), 0f, baseTurnSpeed * Time.deltaTime, 1f, moveSpeedTurnMod); 
        float diff = targetSpeed - currentSpeed;
        
        currentSpeed += diff * accelerationRate;
    }

    void UpdateTurn()
    {
        float targetTurnSpeed = yawControlState * baseTurnSpeed * Time.deltaTime * 
            Utilities.MapValues(Mathf.Abs(currentSpeed), 0f, baseMoveSpeed * Time.deltaTime, 1f, turnMoveSpeedMod);
        float diff = targetTurnSpeed - currentTurnSpeed;

        currentTurnSpeed += diff * accelerationRate;
    }

    void AdjustThrottle(float adjustVal)
    {
        throttleState += adjustVal * throttleAdjustSpeed * Time.deltaTime;
        throttleState = Mathf.Clamp(throttleState, reverseSpeed, 1f);
    }

    void AdjustYaw(float adjustVal)
    {
        yawControlState += adjustVal * yawAdjustSpeed * Time.deltaTime;
        yawControlState = Mathf.Clamp(yawControlState, -1f, 1f);
    }
}
