using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAnimationController : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemyController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
    }

    void FixedUpdate()
    {
        if (enemyController.enemy.health.health <= 0)
        {
            animator.SetBool("Dead", true);
        }

        if (enemyController.isAttacking)
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        if(enemyController.isWalking)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
