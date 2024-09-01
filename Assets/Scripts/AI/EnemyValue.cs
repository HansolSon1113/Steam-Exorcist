using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EnemyValue : Entity
{
    public bool playerFound = false;
    public List<Damage> damage;
    public int scrapCount { get; set; }
    [HideInInspector] public EnemyIndicator enemyIndicator;
}
