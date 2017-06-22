using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Animator myAnimator;

    private void OnEnable()
    {
        SetIntialRefernce();

        enemyMaster.EventEnemyDie += DisableAnimator;
        enemyMaster.EventEnemyAttack += SetAnimatorToAttack;
        enemyMaster.EventEnemyRechedNavTarget += SetAnimatorToIdle;
        enemyMaster.EventEnemyDedectHealth += SetAnimatorToStruck;
        enemyMaster.EventEnemyWalking += SetAnimatorToWalk;



    }
    private void OnDisable()
    {

        enemyMaster.EventEnemyDie -= DisableAnimator;
        enemyMaster.EventEnemyAttack -= SetAnimatorToAttack;
        enemyMaster.EventEnemyRechedNavTarget -= SetAnimatorToIdle;
        enemyMaster.EventEnemyDedectHealth -= SetAnimatorToStruck;
        enemyMaster.EventEnemyWalking -= SetAnimatorToWalk;

    }


    void SetIntialRefernce()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<Animator>()!= null)
        {
            myAnimator = GetComponent<Animator>();

        }


    }




    void SetAnimatorToWalk()
    {

        if (myAnimator != null)
        {

            if (myAnimator.enabled)
            {

                myAnimator.SetBool("isPursuing", true);
            }
        }




    }


    void SetAnimatorToIdle()
    {

        if (myAnimator != null)
        {

            if (myAnimator.enabled)
            {

                myAnimator.SetBool("isPursuing", false);
            }
        }
    }


    void SetAnimatorToAttack()
    {

        if (myAnimator != null)
        {

            if (myAnimator.enabled)
            {

                myAnimator.SetTrigger("Attack");
            }
        }


    }

    void SetAnimatorToStruck(int dummy)
    {

        if (myAnimator != null)
        {

            if (myAnimator.enabled)
            {

                myAnimator.SetTrigger("Struck");
            }
        }


    }

    void DisableAnimator()
    {

        if(myAnimator != null)
        {
           myAnimator.enabled = false;
        }
    }

}
