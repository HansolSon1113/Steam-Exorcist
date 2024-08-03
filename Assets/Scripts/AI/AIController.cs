using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Transform target;
    private Coroutine searchCoroutine;
    public float speed = 5f;
    public EnemyValue enemy;

    void Start()
    {
        target = PlayerController.movementController.playerTransform.transform;
        enemy = GetComponent<EnemyController>().enemy;
        enemy.aiController = this;
        searchCoroutine = StartCoroutine(Search());
    }

    void Update()
    {
        if (enemy.playerFound)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * 5 * Time.deltaTime);
        }
        else
        {
            this.transform.position += new Vector3(enemy.direction * speed * Time.deltaTime, 0, 0);
        }

        if (enemy.playerFound && (target.position - this.transform.position).magnitude > 10f)
        {
            enemy.playerFound = false;
            if (searchCoroutine == null)
            {
                searchCoroutine = StartCoroutine(Search());
            }
        }

        if (!enemy.playerFound && searchCoroutine == null)
        {
            searchCoroutine = StartCoroutine(Search());
        }
    }

    private IEnumerator Search()
    {
        while (!enemy.playerFound)
        {
            enemy.direction = dir.left;
            yield return new WaitForSeconds(1f);
            enemy.direction = dir.right;
            yield return new WaitForSeconds(2f);
            enemy.direction = dir.left;
            yield return new WaitForSeconds(1f);
        }

        searchCoroutine = null;
    }


}
