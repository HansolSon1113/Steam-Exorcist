using UnityEngine;

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
    public Damage damage { get; set; }
    public bool isFlying { get; set; }
    public bool playerFound { get; set; }
    public bool canFly { get; set; }
    public bool canMove { get; set; }
    public bool canAttack { get; set; }
}