using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    private EnemyController enemyController;
    public float vertSpeed;

    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        enemyController.attackPattern.Add(() => enemyController.enemy.aiController.rb.AddForce(Vector2.right * 10 * enemyController.enemy.direction, ForceMode2D.Impulse));
    }

    private void Jump()
    {
        enemyController.enemy.aiController.rb.AddForce(Vector2.up * vertSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoDamage.toTarget(PlayerController.player, enemyController.enemy.damage[0]);
        }
    }
}
