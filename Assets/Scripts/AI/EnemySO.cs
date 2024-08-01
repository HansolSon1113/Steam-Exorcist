using UnityEngine;

[System.Serializable]
public class EnemyElements
{
    public string name;
    public EnemyValue enemy;
    public float health;
    public float maxHealth;
    public float barrier;
    public bool canMove;
    public bool canFly;
    public bool canAttack;
    public int scrapCount;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public EnemyElements[] enemies;
}
