using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    private bool landed;
    public bool defend;

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
            animator.SetBool("isRun", false);
        }
        else if (PlayerController.movementController.player.velocity.x > 0)
        {
            animator.SetBool("isRun", true);
        }
        else if (PlayerController.movementController.player.velocity.x < 0)
        {
            animator.SetBool("isRun", true);
        }
    
        if(PlayerController.player.isFlying == true && landed == false)
        {
            animator.SetBool("Flying", true);
        }
        else
        {
            animator.SetBool("Flying", false);
        }

        if(defend == true)
        {
            animator.SetBool("Defend", true);
        }
        else
        {
            animator.SetBool("Defend", false);
        }

        if(PlayerController.playerAttack.animate == true)
        {
            animator.SetBool("Attack", true);
            PlayerController.playerAttack.animate = false;
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Terrain" || other.gameObject.tag == "Ground")
        {
            landed = true;
            animator.SetBool("Landed", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Terrain")
        {
            landed = false;
            animator.SetBool("Landed", false);
        }
    }
}
