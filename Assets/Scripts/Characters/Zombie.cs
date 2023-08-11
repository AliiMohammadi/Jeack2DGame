using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// دستورات کاراکتر زامبی
/// </summary>
public class Zombie : GameCharacter
{
    private Rigidbody2D rigid;
    private Animator animator;

    public float Speed = 1;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Health <= 0)
        {
            Die();
        }

        if (!IsMoveing)
            animator.SetInteger("Speed",0);

    }
    void OnTriggerEnter2D(Collider2D Tirget)
    {
        if (Tirget.gameObject.tag == "Bullet")
        {
            if (!IsAlive)
                return;

            TakeDamage(25);
            Destroy(Tirget.gameObject);
        }
    }

    public override void Move(TowDDirections Direction)
    {
        if (!IsAlive)
            return;
        if (HoldingGaurd)
            return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attaking"))
            return;

        float RealSpeed = Speed * Time.deltaTime * 1000;
        animator.SetInteger("Speed", (int)RealSpeed);
        switch (Direction)
        {
            case TowDDirections.Left:
                if (BodySide == TowDDirections.Right)
                {
                    Flip();
                }
                //transform.Translate(new Vector2(-RealSpeed, 0));
                rigid.AddForce(new Vector2(-RealSpeed, 0));
                break;
            case TowDDirections.Right:
                if (BodySide == TowDDirections.Left)
                {
                    Flip();
                }
                //transform.Translate(new Vector2(RealSpeed, 0));
                rigid.AddForce(new Vector2(RealSpeed, 0));
                break;

            default:
                break;
        }

    }
    public override void Flip()
    {
        if (!IsAlive)
            return;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if (transform.localScale.x < 0)
        {
            BodySide = TowDDirections.Left;
        }
        if (transform.localScale.x > 0)
        {
            BodySide = TowDDirections.Right;
        }
    }
    public override void TakeDamage(int damage)
    {
        if (!IsAlive)
            return;

        Health -= damage;

        float DamageThrowForce = (Speed * Time.deltaTime * 1000) * 8;

        FreezAframe();

        switch (BodySide)
        {
            case TowDDirections.Left:
                rigid.AddForce(new Vector2(DamageThrowForce, 0));

                break;
            case TowDDirections.Right:
                rigid.AddForce(new Vector2(-DamageThrowForce, 0));
                break;
        }

        animator.SetTrigger("Hitted");
    }
    public override void Attack()
    {
        FreezAframe();
        animator.SetTrigger("Attack");
    }
    public override void Die()
    {
        FreezAframe();
        Health = 0;
        animator.SetBool("Alive",false);

        try
        {
            OnDeath();
        }
        catch (System.Exception)
        {
        }
    }
    public override void SwitchWeapone()
    {
        
    }

    void FreezAframe()
    {
        rigid.velocity = Vector2.zero;
    }
}
