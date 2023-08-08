using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolidSnake : GameCharacter
{
    private Rigidbody2D rigid;
    private Animator animator;

    [SerializeField]
    private bool Armed = false;
    [SerializeField]
    private Transform FierPoint;

    public GameObject Bullet;

    public float Speed = 1;
    public int Magazine = 3;
    public int Ammunition = 12;

    bool IsFalling
    {
        get
        {
            if (Mathf.Abs(rigid.velocity.y) > 0.2f)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        CheckHealth();
        SetAnimatorStates();

    }
    void OnTriggerEnter2D(Collider2D Tirget)
    {
        if (Tirget.gameObject.tag == "ZombieDamage")
        {
            TakeDamage(25);
        }
    }

    void CheckHealth()
    {
        if (!IsAlive)
        {
            Die();
        }
    }
    void SetAnimatorStates()
    {
        if (!IsMoveing)
        {
            animator.SetInteger("AnimationState", 0);
        }

        animator.SetBool("Armed", Armed);
        animator.SetBool("Falling", IsFalling);
        animator.SetBool("Aiming", HoldingGaurd);
    }
    void Fier()
    {
        Ammunition--;
        Bullet Bu = Instantiate(Bullet, FierPoint.position, FierPoint.rotation).GetComponent<Bullet>();

        switch (BodySide)
        {
            case TowDDirections.Left:
                Bu.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                Bu.Direction = -Bu.transform.right;
                break;
            case TowDDirections.Right:
                Bu.Direction = Bu.transform.right;
                break;
            default:
                break;
        }
    }
    void Reload ()
    {
        Ammunition = 12;
        Magazine--;
    }

    public override void Attack()
    {
        if (HoldingGaurd)
        {
            if (Ammunition > 0)
            {
                animator.SetTrigger("Fier");
            }
            else if (Magazine > 0)
            {
                animator.SetTrigger("Reloading");
            }
        }
    }
    public override void Die()
    {
        Health = 0;
        animator.SetTrigger("Death");
    }
    public override void Move(TowDDirections Direction)
    {
        if (!HoldingGaurd)
        {
            float RealSpeed = Speed * Time.deltaTime * 1000;
            animator.SetInteger("AnimationState", 1);
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
    public override void TakeDamage(int damage)
    {
        Health -= damage;
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
    public override void SwitchWeapone()
    {
        Armed = !Armed;
    }
}
