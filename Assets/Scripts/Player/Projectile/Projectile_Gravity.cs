using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Gravity : MonoBehaviour
{
    public Damage damage;
    public float speed = 10f;

    public void Setup(Damage _damage)
    {
        damage = _damage;
    }

    private void Start()
    {
        float rotation = transform.rotation.eulerAngles.z;
        Vector3 forceDirection = Quaternion.Euler(0f, 0f, rotation) * Vector3.right;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * 500f);
    }
}
