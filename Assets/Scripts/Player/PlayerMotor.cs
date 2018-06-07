using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : Motor
{
    [SerializeField] private float movementSpeed = 1f;

    private Rigidbody rb;

    private Vector3 inputVector;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (inputVector == Vector3.zero)
            return;
        
        rb.velocity = inputVector * movementSpeed;
    }

    public override void Move(Vector2 inputVector)
    {
        inputVector = new Vector3(inputVector.x, 0f, inputVector.y); ;
    }

    public override void UseUpAbility(bool pressed)
    {
        throw new System.NotImplementedException();
    }

    public override void UseDownAbility(bool pressed)
    {
        throw new System.NotImplementedException();
    }

    public override void UseLeftAbility(bool pressed)
    {
        throw new System.NotImplementedException();
    }

    public override void UseRightAbility(bool pressed)
    {
        throw new System.NotImplementedException();
    }
}
