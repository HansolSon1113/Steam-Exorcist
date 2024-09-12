using UnityEngine;
using System.Collections;

public class AICollision : MonoBehaviour
{
    private bool hasChangedDirection = false;
    private EnemyController enemy;

    void Start()
    {
        enemy = GetComponent<EnemyController>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            DoDamage.toTarget(enemy.enemy, other.GetComponent<PlayerDamage>().damage);
            if (other.GetComponent<PlayerDamage>().damage.isProjectile)
            {
                Destroy(other.gameObject);
            }
            //enemy.enemyIndicator.UpdateHealthBar(enemy.health);
            other.gameObject.SetActive(false);
            KnockBack(PlayerController.player.direction, 3f);
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
        else if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Edge") && !hasChangedDirection)
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

    public void KnockBack(int direction, float force)
    {
        enemy.aiController.rb.velocity = Vector2.zero;
        enemy.aiController.rb.AddForce(((Vector2.right * direction) + Vector2.up) * force, ForceMode2D.Impulse);
        StartCoroutine(RestoreVelocity());
    }

    private IEnumerator RestoreVelocity()
    {
        float elapsedTime = 0f;
        float duration = 0.5f;
        Vector2 initialVelocity = enemy.aiController.rb.velocity;
        Vector2 targetVelocity = Vector2.zero;

        while (elapsedTime < duration)
        {
            enemy.aiController.rb.velocity = Vector2.Lerp(initialVelocity, targetVelocity, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        enemy.aiController.rb.velocity = targetVelocity;
    }
}