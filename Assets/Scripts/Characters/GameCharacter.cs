using System;
using UnityEngine;

/// <summary>
/// کلاس بیس برای هر کاراکتر زنده داخل بازی و رفتار های انان
/// </summary>
public abstract class GameCharacter : MonoBehaviour
{
    public Action OnDeath;

    /// <summary>
    /// ایا درحال حرکت است
    /// </summary>
    [HideInInspector]
    public bool IsMoveing;
    [HideInInspector]
    public bool HoldingGaurd = false;

    /// <summary>
    /// میزان سلامتی کاراکتر
    /// </summary>
    public int Health = 100;
    public TowDDirections BodySide = TowDDirections.Right;

    /// <summary>
    /// ایا کاراکتر باتوجه به میزان سلامتی زنده هست یا خیر
    /// </summary>
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
