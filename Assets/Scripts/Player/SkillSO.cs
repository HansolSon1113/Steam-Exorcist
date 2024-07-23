using UnityEngine;

[System.Serializable]
public class SkillList
{
    public string name;
    public Sprite cardSprite;
    public SkillElements[] skill;
}

[System.Serializable]
public class SkillElements
{
    public string name;
    public Damage damage;
    public float speed;
    public bool projectile;
}

[CreateAssetMenu(fileName = "SkillSO", menuName = "Scriptable Objects/SkillSO")]
public class SkillSO : ScriptableObject
{
    public SkillList[] skills;
}
