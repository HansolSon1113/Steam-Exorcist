using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendEffect : MonoBehaviour
{
    public bool shieldHit;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(shieldHit == true)
        {
            animator.SetBool("Hit", true);
            shieldHit = false;
        }
        else
        {
            animator.SetBool("Hit", false);
        }   
    }
}
