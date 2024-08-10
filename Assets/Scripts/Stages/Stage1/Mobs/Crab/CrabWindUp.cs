using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabWindUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" && PlayerController.movementController.player.velocity.y < -7.5f)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
