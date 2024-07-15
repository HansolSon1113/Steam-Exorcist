using UnityEngine;

[System.Serializable]
public class EnemyElements
{
    public string name;
    public EnemyPrefab enemyPrefab;
    public Damage damage;
    public bool ally;
}

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public EnemyElements[] enemies;
}
