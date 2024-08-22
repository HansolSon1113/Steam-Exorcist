using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefendShield : MonoBehaviour
{
    [SerializeField] float knockBackForce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyDamage")
        {
            EnemyDamage enemyDamage = other.gameObject.GetComponent<EnemyDamage>();
            if(enemyDamage.damage.isProjectile)
            {
                Destroy(other.gameObject);
            }
            else
            {
                enemyDamage.KnockBack(PlayerController.player.direction, knockBackForce);
            }
        }
    }
}
