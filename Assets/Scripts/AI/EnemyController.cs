using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    private EnemyValue _enemy;

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
    }
    
    public EnemyValue enemy { get; set; }
}