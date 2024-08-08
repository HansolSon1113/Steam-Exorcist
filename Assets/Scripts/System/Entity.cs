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
    public bool canFly;
    public bool canMove;
    public bool canAttack;
    public float attackSpeed;
}


public class dir
{
    public const int right = 1;
    public const int left = -1;
    public const int opposite = -1;
}