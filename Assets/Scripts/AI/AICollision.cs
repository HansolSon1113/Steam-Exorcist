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
            enemy.aiSensor.maxX = enemy.terrainTransform.position.x + enemy.terrainTransform.localScale.x / 2f;
            enemy.aiSensor.minX = enemy.terrainTransform.position.x - enemy.terrainTransform.localScale.x / 2f;
        }
    }
}
