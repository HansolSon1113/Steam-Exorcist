using UnityEngine;

[System.Serializable]
public class ItemElements
{
    public string name;
    public GameObject fieldPrefab;
    public GameObject uiPrefab;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemElements[] items;
}
