using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangedAttack : MonoBehaviour
{
    private float chargeTime = 0f;
    private float maxChargeTime = 0.5f;
    [SerializeField] Animator animator;

    private void Start()
    {
        this.transform.SetParent(PlayerController.movementController.playerTransform);
        PlayerController.animationManager.animator.SetBool("CloseRangedAttack", true);
    }

    private void Update()
    {
        chargeTime += Time.deltaTime;
        if (Input.GetKey(KeySettings.skillAttackKey))
        {
            if (chargeTime >= maxChargeTime)
            {
                animator.SetBool("ChargeComplete", true);
            }
        }
        else if(chargeTime < maxChargeTime)
        {
            Destroy(this.gameObject);
            PlayerController.animationManager.animator.SetBool("CloseRangedAttack", false);

        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("CloseRangeAttack") == true)
        {
            float animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            Debug.Log(animTime);
            if(animTime >= 1)
            {
                Destroy(this.gameObject);
                PlayerController.animationManager.animator.SetBool("CloseRangedAttack", false);
            }
        }
    }
}
