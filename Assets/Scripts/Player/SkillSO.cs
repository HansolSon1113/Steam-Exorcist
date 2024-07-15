using UnityEngine;

[System.Serializable]
public class SkillElements
{
    public string name;
    public Sprite cardSprite;
    public GameObject prefab;
    public Damage damage;
    public bool ally;
}

[CreateAssetMenu(fileName = "SkillSO", menuName = "Scriptable Objects/SkillSO")]
public class SkillSO : ScriptableObject
{
    public SkillElements[] skills;
}
