using UnityEngine;

[System.Serializable]
public class Entity
{
    public float armor; // %
    [HideInInspector] public Health health;
    public int direction; // dir.left, dir.right
    public float invDuration;
    public bool isInvincible;
    public bool isFlying;
    public bool _canFly;
    public bool _canMove;
    public bool _canAttack;
    public float attackSpeed;
}


public class dir
{
    public const int right = 1;
    public const int left = -1;
}