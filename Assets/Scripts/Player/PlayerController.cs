using UnityEngine;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public PlayerValues playerValues;
    public static MovementController movementController;
    public static Damage damage;

    public void Start()
    {
        player = playerValues.player;
        player.direction = playerValues.direction;
        player.isFlying = playerValues.isFlying;
        player.attackSpeed = playerValues.attackSpeed;
        damage = playerValues.damage;
        player.health = new Health(playerValues._health, playerValues._maxHealth);
    }

    public static Entity player { get; set; }
}
