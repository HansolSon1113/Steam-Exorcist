using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(PlayerController.player.direction == dir.left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(PlayerController.player.direction == dir.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (PlayerController.movementController.h == 0)
        {
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", false);
            animator.SetBool("isRun", false);
        }
        else if (PlayerController.movementController.player.velocity.x >= PlayerController.movementController.horSpeed)
        {
            animator.SetBool("RunRight", true);
            animator.SetBool("RunLeft", false);
            animator.SetBool("isRun", true);
        }
        else if (PlayerController.movementController.player.velocity.x <= -PlayerController.movementController.horSpeed)
        {
            animator.SetBool("RunLeft", true);
            animator.SetBool("RunRight", false);
            animator.SetBool("isRun", true);
        }
    }
}
