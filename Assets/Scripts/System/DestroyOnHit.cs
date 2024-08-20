using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "EnemyDamage" &&  other.GetComponent<EnemyDamage>().damage.isProjectile) || (other.gameObject.tag == "PlayerDamage" && other.GetComponent<Projectile_Example>().damage.isProjectile))
        {
            Destroy(other.gameObject);
        }
    }
}
