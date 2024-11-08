using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRangedAttack : MonoBehaviour
{
    private float chargeTime = 0f;
    private float maxChargeTime = 2f;
    [SerializeField] Animator animator;
    private bool chargeComplete = false;
    private float speed;
    [SerializeField] GameObject projectile;
    private Vector3 direction;
    [SerializeField] PlayerDamage playerDamage;

    private void Start()
    {
        this.transform.SetParent(PlayerController.movementController.playerTransform);
        PlayerController.animationManager.animator.SetBool("ProjectileRangedAttack", true);
        speed = playerDamage.speed;
        direction = -transform.up;
    }

    private void Update()
    {
        chargeTime += Time.deltaTime;
        if (Input.GetKey(KeySettings.skillAttackKey))
        {
            if (chargeTime >= maxChargeTime)
            {
                animator.SetBool("ChargeComplete", true);
                chargeComplete = true;
                projectile.SetActive(true);
                this.transform.SetParent(null);
            }
        }
        else if(chargeTime < maxChargeTime)
        {
            Destroy(this.gameObject);
            PlayerController.animationManager.animator.SetBool("ProjectileRangedAttack", false);
        }

        if(chargeComplete)
        {
            this.transform.position += direction * Time.deltaTime * speed;
        }
    }
}