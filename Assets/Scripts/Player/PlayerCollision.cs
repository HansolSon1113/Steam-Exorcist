using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] HealthIndicator healthIndicator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemySensor")
        {
            other.GetComponentInParent<EnemyController>().enemy.playerFound = true;
        }

        if (other.gameObject.tag == "EnemyDamage")
        {
            DoDamage.toTarget(PlayerController.player, other.GetComponent<Projectile_Gravity>().damage);
            if (!PlayerController.player.isInvincible)
            {
                StartCoroutine(PlayerController.Invincible());
            }
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Jumpable" && PlayerController.movementController.player.velocity.y == 0) || (other.gameObject.tag == "Enemy" && PlayerController.movementController.player.velocity.y < 0.2)) && PlayerController.movementController.v == 0)
        {
            PlayerController.player.isFlying = false;
        }

        if (other.gameObject.tag == "Item")
        {
            ItemManager.playerItems.Add(other.gameObject.GetComponent<ItemController>().item);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Scrap")
        {
            GoodsManager.scraps++;
            Destroy(other.gameObject);
        }
    }

    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Jumpable")
    //     {
    //         Player.isFlying = true;
    //     }
    // }
}
