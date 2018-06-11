using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostAbility : Ability
{
    [SerializeField]
    private float boostFactor = 1.5f;
    private Motor motor;

    void Start()
    {
        motor = GetComponent<Motor>();
    }

    public override void Activate(bool activated)
    {
        motor.ModifySpeed(activated ? boostFactor : 1f);
    }
}
