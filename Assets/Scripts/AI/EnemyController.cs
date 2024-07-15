using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        enemy = new Enemy();
        enemy.health = new Health(50, 50);
        enemy.isFlying = false;
        enemy.playerFound = false;
        enemy.canFly = false;
        enemy.canMove = true;
        enemy.canAttack = true;
    }

    public Enemy enemy { get; set; }
}
