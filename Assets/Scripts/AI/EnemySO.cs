using UnityEngine;

[System.Serializable]
public class EnemyElements
{
    public string name;
    public EnemyValue enemy;
    public float health;
    public float maxHealth;
    public float barrier;
    public int scrapCount;
    public GameObject prefab;
    public bool canMove;
    public bool canFly;
    public bool canAttack;
}

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public EnemyElements[] enemies;
}
