[System.Serializable]
public class Damage
{
    public int minDamage;
    public int maxDamage;
    public float critChance;
    public float critMultiplier;
    public float armorPenetration;
    public bool ally;

    public Damage(int minDamage, int maxDamage, float critChance, float critMultiplier, float armorPenetration, bool ally)
    {
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.critChance = critChance;
        this.critMultiplier = critMultiplier;
        this.armorPenetration = armorPenetration;
        this.ally = ally;
    }
}
