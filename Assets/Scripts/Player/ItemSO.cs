using UnityEngine;

[System.Serializable]
public class ItemElements
{
    public string name;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemElements[] items;
}
