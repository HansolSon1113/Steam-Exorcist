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
        player.attackSpeed = playerValues.attackSpeed;
        damage = playerValues.damage;
        player.health = new Health(playerValues._health, playerValues._maxHealth, playerValues.barrier);
    }

    public static IEnumerator Invincible()
    {
        player.isInvincible = true;
        yield return new WaitForSeconds(player.invDuration);
        player.isInvincible = false;
    }

    public static Entity player { get; set; }
}
