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
        float rotation = this.transform.rotation.z;
        rb.AddForce(new Vector2(Mathf.Cos(rotation) * 10, Mathf.Sin(rotation) * 10), ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.velocity *= 0.9f;
    }
}
