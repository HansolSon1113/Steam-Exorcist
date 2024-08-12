using UnityEngine;

[System.Serializable]
public class SkillList
{
    public string name;
    public Sprite indicatorSprite;
    public SkillElements[] skill;
}

[System.Serializable]
public class SkillElements
{
    public string name;
    public Damage damage;
    public float speed;
}

[CreateAssetMenu(fileName = "SkillSO", menuName = "Scriptable Objects/SkillSO")]
public class SkillSO : ScriptableObject
{
    public SkillList[] skills;
}
