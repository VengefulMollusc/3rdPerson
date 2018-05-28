using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Motor currentMotor;

    [Header("Control Settings")]
    [SerializeField]
    private string xMovAxis = "Horizontal";
    [SerializeField]
    private string yMovAxis = "Vertical";
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
        currentMotor.Move(Input.GetAxisRaw(xMovAxis), Input.GetAxisRaw(yMovAxis));

        //// Get vertical and horizontal camera movement
        //float xMov = Input.GetAxisRaw(xCamAxis) * Time.deltaTime;
        //float yMov = Input.GetAxisRaw(yCamAxis) * Time.deltaTime;
        //currentMotor.MoveCamera(xMov, yMov);

        //// Check for Jump
        //if (Input.GetButtonDown(jumpButton))
        //    currentMotor.Jump(true);

        //if (Input.GetButtonUp(jumpButton))
        //    currentMotor.Jump(false);

        //// Check for Crouch
        //if (Input.GetButtonDown(crouchButton))
        //    currentMotor.Crouch(true);

        //if (Input.GetButtonUp(crouchButton))
        //    currentMotor.Crouch(false);
    }
}
