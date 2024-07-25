using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] ItemSO itemSO;
    private List<ItemElements> _itemList = new List<ItemElements>();
    public List<ItemElements> itemList = new List<ItemElements>();

    private void Start()
    {
        foreach (ItemElements item in itemSO.items)
        {
            _itemList.Add(item);
        }

        while(_itemList.Count > 0)
        {
            int rand = Random.Range(0, _itemList.Count);
            itemList.Add(_itemList[rand]);
            _itemList.RemoveAt(rand);
        }
    }
}
