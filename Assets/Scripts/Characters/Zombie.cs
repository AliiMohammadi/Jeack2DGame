using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : GameCharacter
{
    private Rigidbody2D rigid;
    private Animator animator;
    public GameObject Damage;


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
            TakeDamage(25);
        }
    }

    public override void Move(TowDDirections Direction)
    {
        if (!IsAlive)
            return;
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
        Destroy(gameObject,5);
    }
    public override void SwitchWeapone()
    {
        
    }


    public void Hit()
    {
        GameObject da = Instantiate(Damage);
        Destroy(da,0.3f);
    }
}
