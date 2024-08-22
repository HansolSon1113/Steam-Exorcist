using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBehaviour : MonoBehaviour
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
        int playerDirection = (PlayerController.movementController.playerTransform.position.x >= enemyController.aiController.aiTransform.position.x) ? 1 : -1;
        enemyController.enemy.direction = playerDirection;
        StartCoroutine(AttackDetail(playerDirection));
    }

    private IEnumerator AttackDetail(int playerDirection)
    {
        yield return new WaitForSeconds(2f);
        enemyController.aiController.rb.AddForce(Vector2.right * 10 * playerDirection, ForceMode2D.Impulse);
    }
}
