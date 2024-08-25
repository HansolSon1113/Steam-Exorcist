using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public PlayerValues playerValues;
    public static MovementController movementController;
    public static Damage damage;

    public void Awake()
    {
        player = playerValues.player;
        player.direction = playerValues.direction;
        player.isFlying = playerValues.isFlying;
        player.isInvincible = playerValues.isInvincible;
        player.canMove = playerValues.canMove;
        player.canFly = playerValues.canFly;
        player.canAttack = playerValues.canAttack;
        player.attackSpeed = playerValues.attackSpeed;
        damage = playerValues.damage;
        player.health = new Health(playerValues._health, playerValues._maxHealth, playerValues.barrier);

        HealthIndicator.Instance.UpdateHealthIndicator();
    }

    public static Entity player { get; set; }


    public void Heal(float amount)
    {
        if (player != null)
        {
            player.health.health = Mathf.Min(player.health.health + amount, player.health.maxHealth);

            HealthIndicator.Instance.UpdateHealthIndicator();
        }
    }
}
