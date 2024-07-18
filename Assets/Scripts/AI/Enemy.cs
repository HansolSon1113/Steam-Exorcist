using UnityEngine;

[System.Serializable]
public class Enemy : Entity
{
    private AIController _aiController;
    private bool _canFly;
    private bool _canMove;
    private bool _canAttack;
    private bool _playerFound = false;

    public Damage damage;
    public AIController aiController { get; set; }
    public bool playerFound { get; set; }
    public bool canFly { get; set; }
    public bool canMove { get; set; }
    public bool canAttack { get; set; }
    [HideInInspector] public EnemyIndicator enemyIndicator;
}
