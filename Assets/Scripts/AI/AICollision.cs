using UnityEngine;

public class AICollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            DoDamage.toTarget(GetComponent<EnemyController>().enemy, other.GetComponent<Projectile_Example>().damage);
            Destroy(other.gameObject);
            if(GetComponent<EnemyController>().enemy.health.health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
