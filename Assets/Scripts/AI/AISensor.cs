using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    public float maxX, minX;
    private Vector3 orgScale;
    public bool isOn = false;
    private AIController aiController;

    private void Start()
    {
        aiController = GetComponentInParent<AIController>();
        orgScale = transform.localScale;
    }

    private void RestoreTransform()
    {
        int dir = (transform.position.x > aiController.terrainTransform.position.x) ? 1 : -1;
        transform.position += new Vector3((aiController.aiTransform.position.x - transform.position.x) * dir * Time.deltaTime, 0, 0);
        transform.localScale += new Vector3((orgScale.x - this.transform.localScale.x) * Time.deltaTime, 0, 0);
    }

    private void FixedUpdate()
    {
        if (isOn)
        {
            if (transform.position.x > maxX - this.transform.localScale.x / 2)
            {
                float excess = transform.position.x - (maxX - this.transform.localScale.x / 2);
                transform.localScale -= new Vector3(excess, 0, 0);
                transform.position = new Vector3(maxX - this.transform.localScale.x / 2, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < minX + this.transform.localScale.x / 2)
            {
                float excess = (minX + this.transform.localScale.x / 2) - transform.position.x;
                transform.localScale -= new Vector3(excess, 0, 0);
                transform.position = new Vector3(minX + this.transform.localScale.x / 2, transform.position.y, transform.position.z);
            }
            else
            {
                if (transform.localScale.x < orgScale.x)
                {
                    RestoreTransform();
                }
            }
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.tag == "Player")
    //     {
    //         aiController.enemyController.enemy.playerFound = true;
    //     }
    // }
}
