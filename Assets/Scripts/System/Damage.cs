using UnityEngine;

[System.Serializable]
public class Damage
{
    public int minDamage;
    public int maxDamage;
    public float critChance;
    public float critMultiplier;
    public float armorPenetration;
    public bool self;
    public bool ignoreTerrain;
    public bool isProjectile;
    public bool useMouseRotation;
    public bool singleTarget;
    public GameObject prefab;
    public bool stun;

    public Damage(int minDamage, int maxDamage, float critChance, float critMultiplier, float armorPenetration, bool ally)
    {
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.critChance = critChance;
        this.critMultiplier = critMultiplier;
        this.armorPenetration = armorPenetration;
    }

    public static void toTarget(Entity target)
    {
        if (!target.isInvincible)
        {
            Health targetHealth = target.health;
            float armor = target.armor;
            if (targetHealth != null)
            {
                float damageAmount = Random.Range(minDamage, maxDamage + 1);
                if (Random.value < critChance / 100f)
                {
                    damageAmount *= critMultiplier;
                }
                float armorReduction = 1 - ((armor - armorPenetration) / 100f);
                damageAmount *= armorReduction;

                if (target.health.barrier == 0)
                {
                    targetHealth.health -= damageAmount;
                }
                else
                {
                    targetHealth.barrier -= damageAmount;
                    if (targetHealth.barrier < 0)
                    {
                        targetHealth.health += targetHealth.barrier;
                        targetHealth.barrier = 0;
                    }
                }
            }
            if(stun)
            {
                target.canMove = false;
                target.canAttack = false;
            }
        }
    }
}
