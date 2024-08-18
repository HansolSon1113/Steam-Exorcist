using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EnemyValue : Entity
{
    private bool _playerFound = false;

    public List<Damage> damage;
    public bool playerFound { get; set; }
    public bool canFly { get; set; }
    public bool canMove { get; set; }
    public bool canAttack { get; set; }
    public int scrapCount { get; set; }
    [HideInInspector] public EnemyIndicator enemyIndicator;
}
