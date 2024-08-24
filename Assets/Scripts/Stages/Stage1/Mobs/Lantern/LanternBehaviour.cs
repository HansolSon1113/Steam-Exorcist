using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternBehaviour : MonoBehaviour
{
    private EnemyController enemyController;
    public float vertSpeed;

    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        enemyController.attackPattern.Add(Attack);
    }

    private void FixedUpdate()
    {
        enemyController.aiController.rb.velocity = new Vector2(0, enemyController.aiController.rb.velocity.y);
        enemyController.aiController.rb.angularVelocity = 0;
    }

    void Attack()
    {
        StartCoroutine(AttackDetail());
    }

    private IEnumerator AttackDetail()
    {
        float targetAngle = Mathf.Atan2(PlayerController.movementController.playerTransform.position.y - this.transform.position.y, PlayerController.movementController.playerTransform.position.x - this.transform.position.x) * Mathf.Rad2Deg + 90;
        var attackObject = Instantiate(enemyController.enemy.damage[0].prefab, this.transform.position, Quaternion.Euler(0, 0, targetAngle));
        attackObject.GetComponent<EnemyDamage>().damage = enemyController.enemy.damage[0];
        yield return null;
    }
}
