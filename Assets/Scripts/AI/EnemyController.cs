using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    private EnemyValue _enemy;

    private void Awake()
    {
        enemy = new EnemyValue();
    }

    public void Setup(EnemyValue enemy, float health, float maxHealth, float barrier)
    {
        this.enemy = enemy;
        enemy.health = new Health(health, maxHealth, barrier);
        enemy.isFlying = false;
        enemy.playerFound = false;
        enemy.enemyIndicator = GetComponent<EnemyIndicator>();
    }

    public EnemyValue enemy { get; set; }
}