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

    private KeyCode upAbility = KeyCode.I;
    private KeyCode downAbility = KeyCode.K;
    private KeyCode leftAbility = KeyCode.J;
    private KeyCode rightAbility = KeyCode.L;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get vertical and horizontal input vectors
        Vector2 inputVector = new Vector2(Input.GetAxis(xMovAxis), Input.GetAxis(yMovAxis));
        if (inputVector.magnitude > 1f)
            inputVector.Normalize();

        currentMotor.Move(inputVector);

        // Abilities
        // Up
        if (Input.GetKeyDown(upAbility))
            currentMotor.UseUpAbility(true);

        if (Input.GetKeyUp(upAbility))
            currentMotor.UseUpAbility(false);

        // Down
        if (Input.GetKeyDown(downAbility))
            currentMotor.UseDownAbility(true);

        if (Input.GetKeyUp(downAbility))
            currentMotor.UseDownAbility(false);

        // Left
        if (Input.GetKeyDown(leftAbility))
            currentMotor.UseLeftAbility(true);

        if (Input.GetKeyUp(leftAbility))
            currentMotor.UseLeftAbility(false);

        // Right
        if (Input.GetKeyDown(rightAbility))
            currentMotor.UseRightAbility(true);

        if (Input.GetKeyUp(rightAbility))
            currentMotor.UseRightAbility(false);
    }
}
