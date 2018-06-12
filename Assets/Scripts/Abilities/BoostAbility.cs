using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostAbility : Ability
{
    [SerializeField]
    private float boostFactor = 1.5f;

    private Motor motor;

    private bool boosting;

    private float currentBoostFactor = 1f;

    void Start()
    {
        motor = GetComponent<Motor>();
    }

    public override void Activate(bool activated)
    {
        boosting = activated;
        StartCoroutine(Boost());
    }

    private IEnumerator Boost()
    {
        while (currentBoostFactor != (boosting ? boostFactor : 1f))
        {
            if (boosting)
            {
                currentBoostFactor += Time.deltaTime * boostFactor;
                if (currentBoostFactor > boostFactor)
                    currentBoostFactor = boostFactor;
            }
            else
            {
                currentBoostFactor -= Time.deltaTime * boostFactor;
                if (currentBoostFactor < 1f)
                    currentBoostFactor = 1f;
            }

            motor.ModifySpeed(currentBoostFactor);
            yield return 0;
        }
    }
}
