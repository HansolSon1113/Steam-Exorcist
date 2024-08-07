using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    [SerializeField] Transform healthBar;

    public void UpdateHealthBar(Health health)
    {
        healthBar.localScale =  new Vector3(health.health / health.maxHealth, healthBar.localScale.y, 0);
    }
}
