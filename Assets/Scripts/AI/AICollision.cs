using UnityEngine;

public class AICollision : MonoBehaviour
{
    [SerializeField] GameObject scrapPrefab;

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
                for(int i = 0; i < enemy.scrapCount; i++)
                {
                    var scrap = Instantiate(scrapPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                }
                Destroy(gameObject);
            }
        }
    }
}
