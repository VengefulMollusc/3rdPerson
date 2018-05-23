using UnityEngine;

public abstract class Motor : MonoBehaviour
{
    public abstract void Move(Vector3 input);

    public abstract void MoveCamera(float xMov, float yMov);

    public abstract void Jump(bool pressed);

    public abstract void Crouch(bool pressed);
}
