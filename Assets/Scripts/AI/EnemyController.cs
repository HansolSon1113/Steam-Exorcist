using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    private EnemyValue _enemy;
    [SerializeField] GameObject scrapPrefab;

    private void Awake()
    {
        enemy = new EnemyValue();
    }

    public void Setup(EnemyValue enemy, float health, float maxHealth, float barrier, bool canMove, bool canFly, bool canAttack, int scrapCount)
    {
        this.enemy = enemy;
        enemy.health = new Health(health, maxHealth, barrier);
        enemy.canMove = canMove;
        enemy.canFly = canFly;
        enemy.canAttack = canAttack;
        enemy.scrapCount = scrapCount;
        enemy.enemyIndicator = GetComponent<EnemyIndicator>();
        enemy.aiController = GetComponent<AIController>();
        enemy.canMove = canMove;
        enemy.canFly = canFly;
        enemy.canAttack = canAttack;
        enemy.scrapCount = scrapCount;
    }

    private void FixedUpdate()
    {
        if (enemy.health.health <= 0)
        {
            for (int i = 0; i < enemy.scrapCount; i++)
            {
                Instantiate(scrapPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            Destroy(gameObject);
        }
    }

    public EnemyValue enemy { get; set; }
}