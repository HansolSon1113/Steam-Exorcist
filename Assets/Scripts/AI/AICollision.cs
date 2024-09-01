using UnityEngine;

public class AICollision : MonoBehaviour
{
    private bool hasChangedDirection = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            var enemy = GetComponent<EnemyController>().enemy;
            DoDamage.toTarget(enemy, other.GetComponent<PlayerDamage>().damage);
            if (other.GetComponent<PlayerDamage>().damage.isProjectile)
            {
                Destroy(other.gameObject);
            }
            enemy.enemyIndicator.UpdateHealthBar(enemy.health);
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = this.GetComponent<AIController>();
        if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Ground")
        {
            enemy.terrainTransform = other.gameObject.transform;
            enemy.aiSensor.isOn = true;
            enemy.maxX = enemy.aiSensor.maxX = enemy.terrainTransform.position.x + other.gameObject.GetComponent<BoxCollider2D>().size.x / 2f;
            enemy.minX = enemy.aiSensor.minX = enemy.terrainTransform.position.x - other.gameObject.GetComponent<BoxCollider2D>().size.x / 2f;
            this.GetComponent<EnemyController>().isWalking = true;
        }
        else if((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Edge") && !hasChangedDirection)
        {
            this.GetComponent<EnemyController>().enemy.direction *= dir.opposite;
            hasChangedDirection = true;
            Invoke("ResetDirectionChange", 0.5f);
        }
    }

    private void ResetDirectionChange()
    {
        hasChangedDirection = false;
    }
}