using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    [SerializeField]
    private float dashDistance = 5f;
    [SerializeField]
    private float dashTime = 0.1f;

    private Motor motor;
    private InputController inputController;

    void Start()
    {
        motor = GetComponent<Motor>();
        inputController = GetComponent<InputController>();
    }

    public override void Activate(bool activated)
    {
        // Dash in input direction
        Vector2 inputVector = inputController.GetInputVector();
        Vector3 dashVector = new Vector3(inputVector.x, 0f, inputVector.y);

        StartCoroutine(Dash(dashVector));
    }

    private IEnumerator Dash(Vector3 dashVector)
    {
        motor.EnableInput(false);
        dashVector.Normalize();
        dashVector *= (dashDistance/dashTime);

        float t = 0f;
        while (t < dashTime)
        {
            transform.position += dashVector * Time.deltaTime;
            t += Time.deltaTime;
            yield return 0;
        }

        motor.EnableInput(true);
    }
}
