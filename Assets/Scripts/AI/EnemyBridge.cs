using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBridge : MonoBehaviour
{
    public EnemyController enemyController;
    public AIController aiController;

    private void Awake()
    {
        enemyController = GetComponentInChildren<EnemyController>();
        aiController = GetComponentInChildren<AIController>();
    }
}
