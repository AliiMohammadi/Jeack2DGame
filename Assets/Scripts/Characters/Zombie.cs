using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : GameCharacter
{
    private Rigidbody2D rigid;
    private Animator animator;
    private BoxCollider2D colider;

    public float Speed = 1;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Health <= 0)
            animator.SetBool("Alive",false);

        if (!IsMoveing)
            animator.SetInteger("Speed",0);

    }

    public override void Move(TowDDirections Direction)
    {
        if (!HoldingGaurd)
        {
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
    }
    public override void Flip()
    {
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
        Health -= damage;

        float DamageThrowForce = Speed * Time.deltaTime * 1000;

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
        animator.SetTrigger("Attack");
    }
    public override void Die()
    {
        Health = 0;
        animator.SetBool("Alive",false);
        colider.enabled = false;
        rigid.gravityScale = 0;
        
    }
    public override void SwitchWeapone()
    {
        
    }

    public void Hit()
    {

    }
}
