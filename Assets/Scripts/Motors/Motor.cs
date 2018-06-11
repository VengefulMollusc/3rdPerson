using UnityEngine;

public abstract class Motor : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField]
    protected float baseMoveSpeed = 4f;
    [SerializeField]
    protected float baseTurnSpeed = 2f;

    [Header("Face Button Abilities")]
    [Tooltip("Y/Triangle Ability")]
    [SerializeField] private Ability upAbility;
    [Tooltip("A/Cross Ability")]
    [SerializeField] private Ability downAbility;
    [Tooltip("X/Square Ability")]
    [SerializeField] private Ability leftAbility;
    [Tooltip("B/Circle Ability")]
    [SerializeField] private Ability rightAbility;

    protected float speedModifier = 1f;

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
