using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float chargeTime = 0f;
    private float maxChargeTime = 0.3f;
    private Animator animator;

    private void Update()
    {
        chargeTime += Time.deltaTime;
        if (Input.GetKeyDown(KeySettings.skillAttackKey))
        {
            if (chargeTime >= maxChargeTime)
            {
                animator.SetBool("ChargeComplete", true);
            }
        }
        else
        {
            chargeTime = 0f;
        }
    }
}
