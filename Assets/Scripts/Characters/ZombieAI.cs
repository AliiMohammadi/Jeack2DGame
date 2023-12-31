﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour 
{
    public GameCharacter charachter;
    public ushort DetectionDistance = 10;
    public List<GameObject> Targets = new List<GameObject>();

    void Update()
    {
        if (charachter.IsAlive)
            ChaseTarget(LookForTagets());
    }

    /// <summary>
    /// به دنبال یک هدف میرود و به او حمله میکند
    /// </summary>
    /// <param name="target"></param>
    public void ChaseTarget(GameObject target)
    {
        if (!charachter.IsAlive)
            return;

        if (target == null)
        {
            charachter.IsMoveing = false;
            return;
        }

        float dis = Vector2.Distance(transform.position, target.transform.position);

        if (dis > 0.7f)
            MoveTo(target.transform.position);
        else
            charachter.Attack();
    }
    /// <summary>
    /// به سمت نقطه ای حرکت میکند
    /// </summary>
    /// <param name="point"></param>
    public void MoveTo(Vector2 point)
    {
        if (!charachter.IsAlive)
            return;

        if (transform.position.x - point.x > 0)
        {
            charachter.Move(TowDDirections.Left);
        }
        else if (transform.position.x - point.x < 0)
        {
            charachter.Move(TowDDirections.Right);
        }

        charachter.IsMoveing = true;
    }

    GameObject LookForTagets()
    {
        Vector2 ObjectPosition = transform.position;

        GameObject NearestTarget = null;

        float mindistance = int.MaxValue;

        foreach (var Target in Targets)
        {
            if (IsInTheSide(Target,DetectionDistance))
            {
                float distance = Vector2.Distance(Target.transform.position, ObjectPosition);

                if (mindistance > distance)
                {
                    NearestTarget = Target;
                    mindistance = distance;
                }
            }
        }

        return NearestTarget;
    }
    bool IsInTheSide(GameObject Target , ushort detectiondistance)
    {
        Vector2 position = transform.position;
        //Cheking if the target is the same floor or not
        float distY = Mathf.Abs(Target.transform.position.y - position.y);

        if (distY <= 3)
        {
            float distX = Mathf.Abs(Target.transform.position.x - position.x);

            if (distX <= detectiondistance)
            {
                return true;
            }
        }

        return false;
    }
}
