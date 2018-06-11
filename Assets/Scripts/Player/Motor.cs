using UnityEngine;

public abstract class Motor : MonoBehaviour
{
    [SerializeField]
    protected float baseMoveSpeed = 4f;
    [SerializeField]
    protected float baseTurnSpeed = 2f;

    protected float speedModifier = 1f;

    [SerializeField] private Ability upAbility;
    [SerializeField] private Ability downAbility;
    [SerializeField] private Ability leftAbility;
    [SerializeField] private Ability rightAbility;

    public abstract void Move(Vector2 input);

    public virtual void UseUpAbility(bool pressed)
    {
        if (upAbility != null)
            upAbility.Activate(pressed);
    }

    public virtual void UseDownAbility(bool pressed)
    {
        if (downAbility != null)
            downAbility.Activate(pressed);
    }

    public virtual void UseLeftAbility(bool pressed)
    {
        if (leftAbility != null)
            leftAbility.Activate(pressed);
    }

    public virtual void UseRightAbility(bool pressed)
    {
        if (rightAbility != null)
            rightAbility.Activate(pressed);
    }

    public virtual void ModifySpeed(float speedMod)
    {
        speedModifier = speedMod;
    }
}
