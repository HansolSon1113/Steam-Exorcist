using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform target;
    public Transform aiTransform;
    public AISensor aiSensor;
    public Transform terrainTransform;
    public float speed = 5f;
    public EnemyController enemyController;
    public Rigidbody2D rb;
    public float maxX, minX;

    void Start()
    {
        target = PlayerController.movementController.playerTransform.transform;
        enemyController = GetComponent<EnemyController>();
    }

    void FixedUpdate()
    {
        if(!enemyController.enemy.playerFound)
        {
            this.transform.position += new Vector3(enemyController.enemy.direction * speed * Time.deltaTime, 0, 0);
        }

        if (enemyController.enemy.playerFound && ((target.position - this.transform.position).magnitude > 10f) || (terrainTransform != null && (this.transform.position.x < minX || this.transform.position.x > maxX)))
        {
            enemyController.enemy.playerFound = false;
            enemyController.isWalking = true;
        }

        if (!enemyController.enemy.playerFound && terrainTransform != null)
        {
            aiSensor.isOn = true;
            Search();
        }
        
        if(enemyController.enemy.direction == dir.left)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(enemyController.enemy.direction == dir.right)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Search()
    {
        if (this.transform.position.x < minX + this.transform.localScale.x / 2)
        {
            enemyController.enemy.direction = dir.left * dir.opposite;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if(this.transform.position.x > maxX - this.transform.localScale.x / 2)
        {
            enemyController.enemy.direction = dir.right * dir.opposite;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}