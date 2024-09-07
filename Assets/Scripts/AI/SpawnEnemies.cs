using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] EnemySO enemySO;
    public List<GameObject> enemies = new List<GameObject>();
    private List<EnemyElements> enemyElements = new List<EnemyElements>();
    void Start()
    {
        foreach(EnemyElements enemyElement in enemySO.enemies)
        {
            enemyElements.Add(enemyElement);
        }

        for(int i = 0; i < this.transform.childCount; i++)
        {
            GameObject spawnLocation = this.transform.GetChild(i).gameObject;
            foreach(EnemyElements enemyElement in enemyElements)
            {
                if(enemyElement.name == spawnLocation.name)
                {
                    var enemy = Instantiate(enemyElement.prefab, spawnLocation.transform.position, Quaternion.identity);
                    EnemyController enemyController = enemy.GetComponentInChildren<EnemyController>();
                    enemyController.Setup(enemyElement.enemy, enemyElement.health, enemyElement.maxHealth, enemyElement.barrier, enemyElement.canMove, enemyElement.canFly, enemyElement.canAttack, enemyElement.scrapCount);
                    enemies.Add(enemy);
                    break;
                }
            }
        }
    }
}
