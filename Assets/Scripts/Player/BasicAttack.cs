using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public Damage damage;
    public float rotationSpeed = 30f;
    private float targetAngle;
    private float currentAngle;

    void Start()
    {
        this.transform.SetParent(PlayerController.movementController.playerTransform);
        targetAngle = currentAngle + 60f;
    }

    void FixedUpdate()
    {
        currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);

        if (currentAngle == targetAngle)
        {
            Destroy(this.gameObject);
        }
    }
}
