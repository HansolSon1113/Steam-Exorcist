using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternAnimationController : MonoBehaviour
{
    private Animator animator;
    private EnemyController enemyController;
    private LanternBehaviour lantern;
    private bool isAttacking;

    private void Start()
    {
        animator = GetComponent<Animator>();
        lantern = GetComponent<LanternBehaviour>();
        enemyController = GetComponent<EnemyController>();
    }

    void FixedUpdate()
    {
        if (enemyController.isAttacking && !isAttacking)
        {
            StartCoroutine(Attack());
        }

        if(enemyController.isWalking)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Attacking", false);
        isAttacking = false;
    }
}
