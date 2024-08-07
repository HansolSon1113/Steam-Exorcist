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
                if((transform.position.x < maxX - orgScale.x && transform.position.x > minX + orgScale.x) && transform.localScale != orgScale)
                {
                    transform.localScale = orgScale;
                    transform.position = aiController.aiTransform.position;
                }
            }
        }
    }
}
