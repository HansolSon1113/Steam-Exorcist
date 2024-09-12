using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [HideInInspector] public Damage damage;
    AIController aiController;

    private void Start()
    {
        if (!damage.isProjectile)
        {
            aiController = gameObject.transform.GetComponentInParent<EnemyController>().aiController;
        }
    }

    private IEnumerator RestoreVelocity()
    {
        float elapsedTime = 0f;
        float duration = 0.5f;
        Vector2 initialVelocity = aiController.rb.velocity;
        Vector2 targetVelocity = Vector2.zero;

        while (elapsedTime < duration)
        {
            aiController.rb.velocity = Vector2.Lerp(initialVelocity, targetVelocity, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        aiController.rb.velocity = targetVelocity;
    }

    public void KnockBack(int direction, float force)
    {
        aiController.rb.velocity = Vector2.zero;
        aiController.rb.AddForce(((Vector2.right * direction) + Vector2.up) * force, ForceMode2D.Impulse);
        StartCoroutine(RestoreVelocity());
    }
}
