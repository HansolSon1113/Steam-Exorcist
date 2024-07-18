using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Example : MonoBehaviour
{
    public Damage damage;
    public float speed = 10f;
    PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = PlayerAttack.Instance;
        damage = playerAttack.damage;
        float rotation = transform.rotation.eulerAngles.z;
        Vector3 forceDirection = Quaternion.Euler(0f, Player.playerController.playerTransform.rotation.eulerAngles.y, rotation * Player.direction) * Vector3.down;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * 500f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Sensor" && other.gameObject.tag != "Sensor_Flying")
        {
            Destroy(this.gameObject);
        }
    }
}
