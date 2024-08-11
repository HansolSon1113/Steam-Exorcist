using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    private EnemyController enemyController;
    public float vertSpeed;
    private bool alreadyAttacked;

    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        enemyController.attackPattern.Add(Attack);
    }

    void Attack()
    {
        Invoke("AttackDetail", 1f);
    }

    void AttackDetail()
    {
        enemyController.enemy.aiController.rb.AddForce(Vector2.right * 10 * enemyController.enemy.direction, ForceMode2D.Impulse);
    }

    private void Jump()
    {
        enemyController.enemy.aiController.rb.AddForce(Vector2.up * vertSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("PlayerHead") || other.gameObject.CompareTag("PlayerBody") || other.gameObject.CompareTag("PlayerFeet")) && alreadyAttacked == false)
        {
            Debug.Log(other.gameObject.tag);
            DoDamage.toTarget(PlayerController.player, enemyController.enemy.damage[0]);
            alreadyAttacked = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerHead") || other.gameObject.CompareTag("PlayerBody") || other.gameObject.CompareTag("PlayerFeet"))
        {
            alreadyAttacked = false;
        }
    }
}
