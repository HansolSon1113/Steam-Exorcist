using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public static void toTarget(Entity target, Damage damage)
    {
        Health targetHealth = target._health;
        if (targetHealth != null)
        {
            int damageAmount = Random.Range(damage.minDamage, damage.maxDamage + 1);
            if (Random.value < damage.critChance)
            {
                damageAmount = (int)(damageAmount * damage.critMultiplier);
            }
            targetHealth.health -= damageAmount;
        }
    }
}