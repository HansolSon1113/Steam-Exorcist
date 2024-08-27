using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternAnimationController : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemyController;
    private LanternBehaviour lantern;
    private bool alreadyAttacked;
    private LanternBehaviour lanternBehaviour;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lantern = GetComponent<LanternBehaviour>();
        enemyController = GetComponent<EnemyController>();
    }

    void FixedUpdate()
    {
        if (lantern.isAttacking && !alreadyAttacked)
        {
            alreadyAttacked = true;
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false);
        }

        if (!enemyController.isAttacking && alreadyAttacked)
        {
            alreadyAttacked = false;
        }

        if (enemyController.isWalking && !lantern.isAttacking)
        {
            animator.SetBool("Walking", true);
        }
        else if(!enemyController.isWalking || lantern.isAttacking)
        {
            animator.SetBool("Walking", false);
        }
    }
}
