using UnityEngine;

[System.Serializable]
public class EnemyElements
{
    public string name;
    public Enemy enemy;
    public float health;
    public float maxHealth;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public EnemyElements[] enemies;
}
