using UnityEngine;

[System.Serializable]
public class Entity
{
    public float armor; // %
    [HideInInspector] public Health health;
    public int direction; // 1 = right, -1 = left
    public bool isFlying;
}
