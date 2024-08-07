using UnityEngine;

[System.Serializable]
public class PlayerValues
{
    public Entity player = new Entity();
    public Health health { get; set; }
    public int direction { get; set; }
    public bool isFlying { get; set; }
    public bool isInvincible { get; set; }
    public bool canMove { get; set; }
    public bool canFly { get; set; }
    public bool canAttack { get; set; }
    public float attackSpeed;
    public Damage damage;
    public float _health; //This is just for setup, use player.health
    public float _maxHealth;
    public float barrier;
}
