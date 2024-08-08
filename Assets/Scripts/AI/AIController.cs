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
    public EnemyValue enemy;
    public Rigidbody2D rb;
    public float maxX, minX;

    void Start()
    {
        target = PlayerController.movementController.playerTransform.transform;
        enemy = GetComponent<EnemyController>().enemy;
    }

    void FixedUpdate()
    {
        if(!enemy.playerFound)
        {
            this.transform.position += new Vector3(enemy.direction * speed * Time.deltaTime, 0, 0);
        }

        if (enemy.playerFound && ((target.position - this.transform.position).magnitude > 10f) || (terrainTransform != null && (this.transform.position.x < minX || this.transform.position.x > maxX)))
        {
            enemy.playerFound = false;
        }

        if (!enemy.playerFound && terrainTransform != null)
        {
            aiSensor.isOn = true;
            Search();
        }
    }

    private void Search()
    {
        if (this.transform.position.x < minX + this.transform.localScale.x / 2)
        {
            enemy.direction = dir.left * dir.opposite;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if(this.transform.position.x > maxX - this.transform.localScale.x / 2)
        {
            enemy.direction = dir.right * dir.opposite;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
