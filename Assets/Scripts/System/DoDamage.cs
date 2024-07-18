using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public static void toTarget(Entity target, Damage damage)
    {
        Health targetHealth = target.health;
        float armor = target.armor;
        if (targetHealth != null)
        {
            float damageAmount = Random.Range(damage.minDamage, damage.maxDamage + 1);
            if (Random.value < damage.critChance / 100f)
            {
                damageAmount *= damage.critMultiplier;
            }
            float armorReduction = 1 - ((armor - damage.armorPenetration) / 100f);

            damageAmount *= armorReduction;
            targetHealth.health -= damageAmount;
            Debug.Log($"{damageAmount} {targetHealth.health}");
        }
    }
}