using UnityEngine;

public class AICollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            DoDamage.toTarget(GetComponent<EnemyController>().enemy, other.GetComponent<Damage>());
            Debug.Log(this.GetComponent<EnemyController>().enemy.health.health);
        }
    }
}
