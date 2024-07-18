using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Gravity : MonoBehaviour
{
    public Damage damage;
    public float speed = 10f;

    private void Start()
    {
        float rotation = transform.rotation.eulerAngles.z;
        Vector3 forceDirection = Quaternion.Euler(0f, 0f, rotation * Player.direction) * Vector3.down;
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
