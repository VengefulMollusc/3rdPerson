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

    public virtual void Move(Vector2 _input)
    {
        if (inputEnabled)
            ApplyMove(_input);
    }

    protected abstract void ApplyMove(Vector2 input);

    public virtual void UseUpAbility(bool _pressed)
    {
        if (inputEnabled && upAbility != null)
            upAbility.Activate(_pressed);
    }

    public virtual void UseDownAbility(bool _pressed)
    {
        if (inputEnabled && downAbility != null)
            downAbility.Activate(_pressed);
    }

    public virtual void UseLeftAbility(bool _pressed)
    {
        if (inputEnabled && leftAbility != null)
            leftAbility.Activate(_pressed);
    }

    public virtual void UseRightAbility(bool _pressed)
    {
        if (inputEnabled && rightAbility != null)
            rightAbility.Activate(_pressed);
    }

    public virtual void ModifySpeed(float _speedMod)
    {
        speedModifier = _speedMod;
    }

    public virtual void EnableInput(bool _enabled)
    {
        inputEnabled = _enabled;
    }
}
