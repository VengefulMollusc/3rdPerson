using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    private Motor motor;

    void Start()
    {
        motor = GetComponent<Motor>();
    }

    public override void Activate(bool activated)
    {
        throw new System.NotImplementedException();
    }
}
