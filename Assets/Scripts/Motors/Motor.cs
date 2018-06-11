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
    protected bool inputEnabled = true;

    public virtual void Move(Vector2 input)
    {
        if (inputEnabled)
            ApplyMove(input);
    }

    protected abstract void ApplyMove(Vector2 input);

    public virtual void UseUpAbility(bool pressed)
    {
        if (inputEnabled && upAbility != null)
            upAbility.Activate(pressed);
    }

    public virtual void UseDownAbility(bool pressed)
    {
        if (inputEnabled && downAbility != null)
            downAbility.Activate(pressed);
    }

    public virtual void UseLeftAbility(bool pressed)
    {
        if (inputEnabled && leftAbility != null)
            leftAbility.Activate(pressed);
    }

    public virtual void UseRightAbility(bool pressed)
    {
        if (inputEnabled && rightAbility != null)
            rightAbility.Activate(pressed);
    }

    public virtual void ModifySpeed(float speedMod)
    {
        speedModifier = speedMod;
    }

    public virtual void EnableInput(bool enabled)
    {
        inputEnabled = enabled;
    }
}
