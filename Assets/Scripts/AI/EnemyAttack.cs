using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private List<Damage> damage;
    private EnemyController enemyController;
    private bool isAttacking;

    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        damage = enemyController.enemy.damage;
    }

    void Update()
    {
        if(enemyController.enemy.playerFound)
        {
            foreach(Damage damage in damage)
            {
                if(!isAttacking)
                {
                    StartCoroutine(Attack(damage));
                }
            }
        }
    }

    private IEnumerator Attack(Damage damage)
    {
        isAttacking = true;
        var attack = Instantiate(damage.prefab, transform.position, Quaternion.identity);
        attack.GetComponent<Projectile_Gravity>().Setup(damage);
        yield return new WaitForSeconds(enemyController.enemy.attackSpeed);
        isAttacking = false;
    }
}
