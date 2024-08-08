using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private List<Damage> damage;
    private EnemyController enemyController;

    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        damage = enemyController.enemy.damage;
    }

    void Update()
    {
        if (enemyController.enemy.playerFound)
        {
            foreach (Damage damage in damage)
            {
                if (!enemyController.isAttacking)
                {
                    StartCoroutine(Attack(damage));
                }
            }
        }
    }

    private IEnumerator Attack(Damage damage)
    {
        if(enemyController.isAttacking)
        {
            yield break;
        }
        enemyController.isAttacking = true;
        {
            foreach(System.Action attack in enemyController.attackPattern)
            {
                Debug.Log(enemyController.enemy.attackSpeed);
                attack();
            }
        }
        yield return new WaitForSeconds(enemyController.enemy.attackSpeed);
        enemyController.isAttacking = false;
    }
}
