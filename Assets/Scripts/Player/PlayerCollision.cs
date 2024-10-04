using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // private Collider2D collider;
    // private PlatformEffector2D effector;

    private void FixedUpdate()
    {
        // if (PlayerController.movementController.v < 0 && collider != null)
        // {
        //     collider.isTrigger = true;
        //     effector.rotationalOffset = 180;
        // }
        // else if (collider != null)
        // {
        //     collider.isTrigger = false;
        //     effector.rotationalOffset = 0;
        // }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Ground" || other.gameObject.tag == "Terrain") && PlayerController.movementController.player.velocity.y == 0 && PlayerController.movementController.v == 0)
        {
            PlayerController.player.isFlying = false;
            // collider = other.collider;
            // effector = other.gameObject.GetComponent<PlatformEffector2D>();
        }

        else if ((other.gameObject.tag == "Enemy" && Mathf.Abs(PlayerController.movementController.player.velocity.y) < 0.08f))
        {
            PlayerController.player.isFlying = false;
        }
    }

    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Terrain")
    //     {
    //         collider = null;
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemySensor")
        {
            var bridge = other.GetComponentInParent<EnemyBridge>();
            bridge.enemyController.enemy.playerFound = true;
            bridge.aiController.aiSensor.isOn = false;
        }

        if (other.gameObject.tag == "EnemyDamage")
        {
            DoDamage.toTarget(PlayerController.player, other.GetComponent<EnemyDamage>().damage);
            if (!PlayerController.player.isInvincible)
            {
                StartCoroutine(PlayerDefend.Invincible());
            }
            if (other.GetComponent<EnemyDamage>().damage.isProjectile)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            ItemManager.playerItems.Add(other.gameObject.GetComponent<ItemController>().item);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Scrap")
        {
            GoodsManager.scraps++;
            Destroy(other.gameObject);
        }
    }
}