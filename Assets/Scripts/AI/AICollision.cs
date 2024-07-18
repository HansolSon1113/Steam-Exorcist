using UnityEngine;

public class AICollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            var enemy = GetComponent<EnemyController>().enemy;
            DoDamage.toTarget(enemy, other.GetComponent<Projectile_Example>().damage);
            Destroy(other.gameObject);
            enemy.enemyIndicator.UpdateHealthBar(enemy.health);
            if(enemy.health.health <= 0)
            {
                Destroy(gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
            }
        }
    }
}
