using UnityEngine;

public class AICollision : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            var enemy = GetComponent<EnemyController>().enemy;
            DoDamage.toTarget(enemy, other.GetComponent<Projectile_Example>().damage);
            Destroy(other.gameObject);
            enemy.enemyIndicator.UpdateHealthBar(enemy.health);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = this.GetComponent<AIController>();
        if (other.gameObject.tag == "Terrain")
        {
            enemy.terrainTransform = other.gameObject.transform;
            enemy.aiSensor.isOn = true;
            enemy.maxX = enemy.aiSensor.maxX = enemy.terrainTransform.position.x + other.gameObject.GetComponent<BoxCollider2D>().size.x / 2f;
            enemy.minX = enemy.aiSensor.minX = enemy.terrainTransform.position.x - other.gameObject.GetComponent<BoxCollider2D>().size.x / 2f;
            this.GetComponent<EnemyController>().isWalking = true;
        }
    }
}
