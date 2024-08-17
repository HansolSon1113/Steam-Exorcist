using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    private EnemyController enemyController;
    public float vertSpeed;
    [SerializeField] EnemyDamage enemyDamage;
    [SerializeField] GameObject enemyDamageObject;

    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        enemyController.attackPattern.Add(Attack);
        enemyDamage.damage = enemyController.enemy.damage[0];
        enemyDamageObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(enemyController.enemy.playerFound && !enemyDamageObject.activeSelf)
        {
            enemyDamageObject.SetActive(true);
        }
    }

    void Attack()
    {
        Invoke("AttackDetail", 2f);
    }

    void AttackDetail()
    {
        enemyController.aiController.rb.AddForce(Vector2.right * 10 * enemyController.enemy.direction, ForceMode2D.Impulse);
    }

    private void Jump()
    {
        enemyController.aiController.rb.AddForce(Vector2.up * vertSpeed, ForceMode2D.Impulse);
    }
}
