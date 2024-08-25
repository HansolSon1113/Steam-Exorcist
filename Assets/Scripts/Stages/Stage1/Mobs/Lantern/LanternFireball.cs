using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFireball : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(0.5f);
        float rotation = transform.rotation.eulerAngles.z;
        this.transform.rotation = Quaternion.Euler(0, 0, rotation + 90);
        Vector3 forceDirection = Quaternion.Euler(0f, 0f, rotation) * Vector3.down;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * speed);
    }
}