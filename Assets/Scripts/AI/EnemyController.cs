using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        enemy = new Enemy();
    }

    public void Setup(Enemy enemy, float health, float maxHealth)
    {
        this.enemy = enemy;
        enemy.health = new Health(health, maxHealth);
        enemy.isFlying = false;
        enemy.playerFound = false;
        enemy.enemyIndicator = GetComponent<EnemyIndicator>();
    }

    public Enemy enemy { get; set; }
}