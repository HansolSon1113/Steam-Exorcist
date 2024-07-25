using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemElements item;
    [SerializeField] Rigidbody2D rb;

    public void Setup(ItemElements _item)
    {
        item = _item;
    }

    private void Start()
    {
        float rotation = transform.rotation.eulerAngles.z;
        rb.AddForce(new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad), Mathf.Sin(rotation * Mathf.Deg2Rad)) * 10, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.velocity *= 0.9f;
    }
}
