using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Master : MonoBehaviour {

    public Transform myTarget;

    public delegate void GeneralEventHandele();
    public event GeneralEventHandele EventEnemyDie;
    public event GeneralEventHandele EventEnemyWalking;
    public event GeneralEventHandele EventEnemyRechedNavTarget;
    public event GeneralEventHandele EventEnemyAttack;
    public event GeneralEventHandele EventEnemyLostTarget;

    public delegate void HealthEventHandeler(int health);
    public event HealthEventHandeler EventEnemyDedectHealth;

    public delegate void NavTargetEventHandeler(Transform targetTransform);
    public event NavTargetEventHandeler EventEnemySetNavTarget;


    public bool isOnRoute;
    public bool isNavPuse;

    public void CallDedectedHealth(int health)
    {

        if (EventEnemyDedectHealth != null)
        {

            EventEnemyDedectHealth(health);
        }

    }

    public void CallEventEnemySetNavTarget(Transform targetTransform)
    {

        if (EventEnemySetNavTarget != null)
        {
            EventEnemySetNavTarget(targetTransform);

        }
        myTarget = targetTransform;
    }

    public void CallEventEnemyDie()
    {
        if (EventEnemyDie != null)
        {
            EventEnemyDie();
        }


    }

    public void CallEventEnemyAttack()
    {
        if (EventEnemyAttack != null)
        {
            EventEnemyAttack();
        }


    }

    public void CallEventEnemyWalking()
    {
        if (EventEnemyWalking != null)
        {
            EventEnemyWalking();
        }


    }
    public void CallEventEnemyLostTarget()
    {
        if (EventEnemyLostTarget != null)
        {
            EventEnemyLostTarget();
        }

        myTarget = null;
    }

    public void CallEventEnemyReachedNavTarget()
    {
        if (EventEnemyRechedNavTarget != null)
        {
            EventEnemyRechedNavTarget();
        }


    }
































}
