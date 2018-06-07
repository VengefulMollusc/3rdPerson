using UnityEngine;

public abstract class Motor : MonoBehaviour
{
    public abstract void Move(Vector2 inputVector);

    public abstract void UseUpAbility(bool pressed);

    public abstract void UseDownAbility(bool pressed);

    public abstract void UseLeftAbility(bool pressed);

    public abstract void UseRightAbility(bool pressed);
}
