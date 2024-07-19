using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyDamage")
        {
            DoDamage.toTarget(Player.player, other.GetComponent<Damage>());
        }
        else if (other.gameObject.tag == "EnemySensor")
        {
            other.GetComponentInParent<EnemyController>().enemy.playerFound = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Jumpable" || other.gameObject.tag == "Enemy") && PlayerController.v == 0)
        {
            Player.isFlying = false;
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
