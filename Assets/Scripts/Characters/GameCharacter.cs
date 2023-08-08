using UnityEngine;

public abstract class GameCharacter : MonoBehaviour
{
    [HideInInspector]
    public bool IsMoveing;
    [HideInInspector]
    public bool HoldingGaurd = false;

    public int Health = 100;
    public TowDDirections BodySide = TowDDirections.Right;

    public bool IsAlive
    {
        get
        {
            return (Health > 0);
        }
    }

    public abstract void Move(TowDDirections Direction);
    public abstract void Flip();
    public abstract void TakeDamage(int damage);
    public abstract void Attack();
    public abstract void Die();
    public abstract void SwitchWeapone();
}

public enum TowDDirections
{
    Left,Right
}
