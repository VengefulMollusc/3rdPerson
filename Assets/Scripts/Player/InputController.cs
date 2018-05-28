using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Motor playerMotor;

    [Header("Control Settings")]
    [SerializeField]
    private string xMovAxis = "Horizontal";
    [SerializeField]
    private string zMovAxis = "Vertical";
    [SerializeField]
    private string xCamAxis = "LookX";
    [SerializeField]
    private string yCamAxis = "LookY";
    [SerializeField]
    private string jumpButton = "Jump";
    [SerializeField]
    private string crouchButton = "Crouch";

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get vertical and horizontal input vectors
        Vector3 movement = new Vector3(Input.GetAxisRaw(xMovAxis), 0f, Input.GetAxisRaw(zMovAxis));
        playerMotor.Move(movement);

        // Get vertical and horizontal camera movement
        float xMov = Input.GetAxisRaw(xCamAxis) * Time.deltaTime;
        float yMov = Input.GetAxisRaw(yCamAxis) * Time.deltaTime;
        playerMotor.MoveCamera(xMov, yMov);

        // Check for Jump
        if (Input.GetButtonDown(jumpButton))
            playerMotor.Jump(true);

        if (Input.GetButtonUp(jumpButton))
            playerMotor.Jump(false);

        // Check for Crouch
        if (Input.GetButtonDown(crouchButton))
            playerMotor.Crouch(true);

        if (Input.GetButtonUp(crouchButton))
            playerMotor.Crouch(false);
    }
}
