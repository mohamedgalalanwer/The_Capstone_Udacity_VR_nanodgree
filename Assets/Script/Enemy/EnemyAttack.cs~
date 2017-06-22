using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyAttack : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Transform attackTarget;
    private Transform myTransform;
    public float attackRate = 1;
    private float nextAttack;
    public float attackRange = 3.5f;
    public int attackDamage = 20;
    public float range = 0.5f;

    public GameObject KillObjectDamage;
    public Transform KillObjectDamagepostion;



    void SetAttackTarget (Transform targetTransform) {
        attackTarget = targetTransform;
	}
	void DiableTHis()
    {
        this.enabled = false;
    }

    void SetIntialRefrance()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        myTransform = transform;

        KillObjectDamagepostion = GameObject.FindGameObjectWithTag("damge").transform;
    }
    private void OnEnable()
    {
        SetIntialRefrance();
        enemyMaster.EventEnemySetNavTarget += SetAttackTarget;
        enemyMaster.EventEnemyDie += DiableTHis;
    }
    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DiableTHis;
        enemyMaster.EventEnemySetNavTarget -= SetAttackTarget;
    }


    void TryToAttack()
    {

        if (attackTarget != null)
        {
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;

                if (Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange)
                {
                    Vector3 lookAtVector3 = new Vector3(attackTarget.position.x, myTransform.position.y, attackTarget.position.z);
                    myTransform.LookAt(lookAtVector3);
                    enemyMaster.CallEventEnemyAttack();
                    enemyMaster.isOnRoute = false;
                }

            }

        }


    }
    // Update is called once per frame
    void OnEnemyAttack() {
        if (attackTarget != null)
        {
            if (Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange && attackTarget.GetComponent<Player_Master>() != null)
            {
                Vector3 toOther = attackTarget.position - myTransform.position;
                if (Vector3.Dot(toOther, myTransform.forward) > range)
                {
                    attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthDeduction(attackDamage);
                    Instantiate(KillObjectDamage, KillObjectDamagepostion.position, KillObjectDamagepostion.rotation);
                  //  Destroy (KillObjectDamage, 0.01f);
                    // هخلى زى دم يظهر قدام الكاميرا
                }

            }
        }
	}

    private void Update()
    {
        TryToAttack();
    }
}
