using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFireball : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        float rotation = transform.rotation.eulerAngles.z;
        Vector3 forceDirection = Quaternion.Euler(0f, 0f, rotation) * Vector3.down;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * speed);
    }
}