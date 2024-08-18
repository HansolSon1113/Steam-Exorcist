using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [HideInInspector] public Damage damage;
    AIController aiController;

    private void Start()
    {
        aiController = gameObject.transform.GetComponentInParent<EnemyController>().aiController;
    }

    private IEnumerator RestoreVelocity()
    {
        yield return new WaitForSeconds(0.25f);
        aiController.rb.velocity = Vector2.zero;
    }

    public void KnockBack(int direction, float force)
    {
        aiController.rb.velocity = Vector2.zero;
        aiController.rb.AddForce(Vector2.right * direction * force, ForceMode2D.Impulse);
        StartCoroutine(RestoreVelocity());
    }
}
